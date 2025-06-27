using FluentValidation;

namespace Company1.Ecommerce.Application.UseCases.Customers.Commands.CreateCustomerCommand;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotNull()
            .NotEmpty()
            .MinimumLength(5);
    }
}
