﻿using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.Infrastructure;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Application.Interface.UseCases;
using Company1.Ecommerce.Domain.Entities;
using Company1.Ecommerce.Domain.Events;
using Company1.Ecommerce.Transverse.Common;
using System.Text.Json;

namespace Company1.Ecommerce.Application.UseCases.Discounts;

public class DiscountsApplication : IDiscountsApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;
    private readonly INotification _notification;

    public DiscountsApplication(IUnitOfWork unitOfWork, IMapper mapper, IEventBus eventBus, INotification notification)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _eventBus = eventBus;
        _notification = notification;
    }

    public async Task<Response<bool>> CreateAsync(DiscountDTO discount, CancellationToken cancellationToken = default)
    {
        var response = new Response<bool>();

        var discountEntity = _mapper.Map<Discount>(discount);
        await _unitOfWork.Discounts.InsertAsync(discountEntity);

        response.Data = await _unitOfWork.SaveAsync(cancellationToken) > 0;
        if (response.Data)
        {
            response.Message = "Discount created successfully";
            response.IsSuccess = true;

            // Publish an event if needed
            var discountCreatedEvent = _mapper.Map<DiscountCreatedEvent>(discountEntity);
            _eventBus.Publish(discountCreatedEvent);

            // Optionally send a notification
            await _notification.SendEmailAsync(response.Message, JsonSerializer.Serialize(discount), cancellationToken);
        }

        return response;
    }

    public async Task<Response<bool>> UpdateAsync(DiscountDTO discount, CancellationToken cancellationToken = default)
    {
        var response = new Response<bool>();

        var discountEntity = _mapper.Map<Discount>(discount);
        await _unitOfWork.Discounts.UpdateAsync(discountEntity);

        response.Data = await _unitOfWork.SaveAsync(cancellationToken) > 0;
        if (response.Data)
        {
            response.Message = "Discount updated successfully";
            response.IsSuccess = true;
        }

        return response;
    }

    public async Task<Response<bool>> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var response = new Response<bool>();
        await _unitOfWork.Discounts.DeleteAsync(id);
        response.Data = await _unitOfWork.SaveAsync(cancellationToken) > 0;
        if (response.Data)
        {
            response.Message = "Discount deleted successfully";
            response.IsSuccess = true;
        }

        return response;
    }

    public async Task<Response<DiscountDTO>> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        var response = new Response<DiscountDTO>();
        var discountEntity = await _unitOfWork.Discounts.GetAsync(id, cancellationToken);
        if (discountEntity is null)
        {
            response.IsSuccess = true;
            response.Message = "Discount not found";
            return response;
        }
        response.Data = _mapper.Map<DiscountDTO>(discountEntity);
        response.IsSuccess = true;
        response.Message = "Discount retrieved successfully";

        return response;
    }

    public async Task<Response<IEnumerable<DiscountDTO>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = new Response<IEnumerable<DiscountDTO>>();
        var discounts = await _unitOfWork.Discounts.GetAllAsync(cancellationToken);
        response.Data = _mapper.Map<IEnumerable<DiscountDTO>>(discounts);
        if (response.Data is null || !response.Data.Any())
        {
            response.IsSuccess = true;
            response.Message = "No discounts found";
            return response;
        }
        response.IsSuccess = true;
        response.Message = "Discounts retrieved successfully";

        return response;
    }


    public async Task<ResponsePagination<IEnumerable<DiscountDTO>>> GetAllAsync(int pageIndex, int pageSize)
    {
        var response = new ResponsePagination<IEnumerable<DiscountDTO>>();
        var count = await _unitOfWork.Discounts.CountAsync();

        var data = await _unitOfWork.Discounts.GetAllAsync(pageIndex, pageSize);
        response.Data = _mapper.Map<IEnumerable<DiscountDTO>>(data);

        if (response.Data is not null)
        {
            response.TotalPages = (int)Math.Ceiling((double)count / pageSize);
            response.TotalRecords = count;
            response.PageIndex = pageIndex;
            response.PageSize = pageSize;
            response.IsSuccess = true;
            response.Message = "Discounts found";
        }

        return response;
    }
}
