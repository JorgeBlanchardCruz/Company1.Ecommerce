﻿using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Application.Interface.UseCases;
using Company1.Ecommerce.Transverse.Common;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Company1.Ecommerce.Application.UseCases;

public class CategoriesApplication : ICategoriesApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IDistributedCache _distributedCache;

    public CategoriesApplication(IMapper mapper, IDistributedCache distributedCache, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _distributedCache = distributedCache;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<IEnumerable<CategoriesDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<CategoriesDTO>>();
        var cacheKey = "CategoriesCacheKey";

        try
        {
            var cachedCategories = await _distributedCache.GetAsync(cacheKey);
            if (cachedCategories is not null)
            {
                response.Data = JsonSerializer.Deserialize<IEnumerable<CategoriesDTO>>(cachedCategories)!;
            }
            else
            {
                var categories = await _unitOfWork.Categories.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CategoriesDTO>>(categories);

                if (response.Data is not null)
                {
                    var serializedCategories = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Data));
                    var cacheOptions = new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(8),
                        SlidingExpiration = TimeSpan.FromMinutes(60)
                    };

                    await _distributedCache.SetAsync(cacheKey, serializedCategories, cacheOptions);
                }

            }

            if (response.Data is not null)
            {
                response.IsSuccess = true;
                response.Message = "Categories retrieved successfully.";
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }

        return response;
    }
}
