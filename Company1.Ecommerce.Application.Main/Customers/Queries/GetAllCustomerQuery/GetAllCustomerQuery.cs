using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Queries.GetAllCustomerQuery;

public sealed record GetAllCustomerQuery : IRequest<Response<IEnumerable<CustomerDTO>>>
{

}
