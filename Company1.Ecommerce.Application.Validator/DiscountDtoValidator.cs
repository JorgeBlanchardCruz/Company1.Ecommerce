using Company1.Ecommerce.Application.DTO;
using FluentValidation;

namespace Company1.Ecommerce.Application.Validator;

public class DiscountDtoValidator : AbstractValidator<DiscountDTO>
{
    public DiscountDtoValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Percentage).NotNull().NotEmpty().WithMessage("Percentage is required");
    }
}
