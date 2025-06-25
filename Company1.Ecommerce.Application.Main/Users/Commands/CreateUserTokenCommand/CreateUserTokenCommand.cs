using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;
using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company1.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand;

public sealed record CreateUserTokenCommand : IRequest<Response<UserDTO>>
{
    [Required]
    [DefaultValue("Jorge")]
    public string UserName { get; init; } = default!;

    [Required]
    [DefaultValue("123456")]
    public string Password { get; init; } = default!;
}
