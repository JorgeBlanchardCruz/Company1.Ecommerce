using Company1.Ecommerce.Application.DTO;
using FluentValidation;

namespace Company1.Ecommerce.Application.Validator;

public class UsersDtoValidator : AbstractValidator<UsersDTO>
{

    public UsersDtoValidator()
    {
        RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("UserName is required");
        RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password is required");
    }
}
