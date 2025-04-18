﻿using Company1.Ecommerce.Application.DTO;
using FluentValidation;

namespace Company1.Ecommerce.Application.Validator;

public class UserDtoValidator : AbstractValidator<UserDTO>
{
    public UserDtoValidator()
    {
        RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("UserName is required");
        RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password is required");
    }
}
