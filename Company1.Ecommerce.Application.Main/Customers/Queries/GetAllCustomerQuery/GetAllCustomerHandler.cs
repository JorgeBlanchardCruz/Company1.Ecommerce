using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Queries.GetAllCustomerQuery;

public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, Response<IEnumerable<CustomerDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<CustomerDTO>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var response = new Response<IEnumerable<CustomerDTO>>();
        var customers = await _unitOfWork.Customers.GetAllAsync(cancellationToken);
        response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        if (response.Data is not null)
        {
            response.IsSuccess = true;
            response.Message = "Customers found";
        }
        return response;
    }
}
