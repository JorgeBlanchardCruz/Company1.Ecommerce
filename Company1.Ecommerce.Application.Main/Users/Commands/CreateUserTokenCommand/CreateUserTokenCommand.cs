using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;
using MediatR;
using System.ComponentModel;

namespace Company1.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand;

public sealed record CreateUserTokenCommand : IRequest<Response<UserDTO>>
{
    [DefaultValue("Jorge")]
    public string UserName { get; init; } = default!;

    [DefaultValue("123456")]
    public string Password { get; init; } = default!;
}
