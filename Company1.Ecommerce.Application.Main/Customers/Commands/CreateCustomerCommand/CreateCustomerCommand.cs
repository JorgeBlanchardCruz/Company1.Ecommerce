using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Commands.CreateCustomerCommand;

public sealed record CreateCustomerCommand : IRequest<Response<bool>>
{
    public string CustomerId { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string ContactName { get; set; } = null!;
    public string ContactTitle { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Fax { get; set; } = null!;
}
