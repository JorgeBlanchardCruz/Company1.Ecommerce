using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Queries.GetAllWithPaginationCustomerQuery;

public class GetAllWithPaginationCustomerHandler : IRequestHandler<GetAllWithPaginationCustomerQuery, ResponsePagination<IEnumerable<CustomerDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllWithPaginationCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponsePagination<IEnumerable<CustomerDTO>>> Handle(GetAllWithPaginationCustomerQuery request, CancellationToken cancellationToken)
    {
        var response = new ResponsePagination<IEnumerable<CustomerDTO>>();
        var count = await _unitOfWork.Customers.CountAsync();

        var customers = await _unitOfWork.Customers.GetAllAsync(request.PageIndex, request.PageSize);
        response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

        if (response.Data is not null)
        {
            response.TotalPages = (int)Math.Ceiling((double)count / request.PageSize);
            response.TotalRecords = count;
            response.PageIndex = request.PageIndex;
            response.PageSize = request.PageSize;
            response.IsSuccess = true;
            response.Message = "Customers found";
        }

        return response;
    }
}
