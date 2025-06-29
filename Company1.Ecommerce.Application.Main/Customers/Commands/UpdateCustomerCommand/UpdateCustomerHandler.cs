using AutoMapper;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Domain.Entities;
using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Commands.UpdateCustomerCommand;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Response<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new Response<bool>();
        var customer = _mapper.Map<Customer>(request);

        var countrySpecification = new Domain.Specifications.CountryinBlackListSpecification();
        if (!countrySpecification.IsSatisfiedBy(customer))
        {
            response.IsSuccess = false;
            response.Message = $"The country is in the blacklist> {customer.Country}";
            return response;
        }

        response.Data = await _unitOfWork.Customers.UpdateAsync(customer);

        if (response.Data)
        {
            response.IsSuccess = true;
            response.Message = "Customer updated successfully";
        }

        return response;
    }
}
