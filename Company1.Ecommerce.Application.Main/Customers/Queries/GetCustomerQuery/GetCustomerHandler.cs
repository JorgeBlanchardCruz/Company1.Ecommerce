using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Queries.GetCustomerQuery;

public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Response<CustomerDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<CustomerDTO>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var response = new Response<CustomerDTO>();
        var customer = await _unitOfWork.Customers.GetAsync(request.CustomerId);

        response.Data = _mapper.Map<CustomerDTO>(customer);
        response.IsSuccess = true;

        return response;
    }
}
