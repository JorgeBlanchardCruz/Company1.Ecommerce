using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Queries.GetCustomerQuery;

public sealed record GetCustomerQuery : IRequest<Response<CustomerDTO>>
{
    public int CustomerId { get; set; } = default!;
}
