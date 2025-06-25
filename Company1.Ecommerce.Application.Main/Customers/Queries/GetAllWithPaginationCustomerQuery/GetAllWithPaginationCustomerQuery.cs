using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Queries.GetAllWithPaginationCustomerQuery;

public sealed record GetAllWithPaginationCustomerQuery : IRequest<ResponsePagination<IEnumerable<CustomerDTO>>>
{
    public int PageIndex { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
