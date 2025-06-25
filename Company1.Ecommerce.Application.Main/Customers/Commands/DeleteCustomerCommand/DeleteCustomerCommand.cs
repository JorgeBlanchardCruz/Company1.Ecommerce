using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Commands.DeleteCustomerCommand;

public sealed record DeleteCustomerCommand : IRequest<Response<bool>>
{
    public int CustomerId { get; set; } = default;
}
