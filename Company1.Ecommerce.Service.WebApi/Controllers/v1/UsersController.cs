using Asp.Versioning;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand;
using Company1.Ecommerce.Service.WebApi.Helpers;
using Company1.Ecommerce.Transverse.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company1.Ecommerce.Service.WebApi.Controllers.v3;

[Authorize]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public class UsersController : Controller
{
    private readonly IMediator _mediator;
    private readonly AppSettings _appSettings;

    public UsersController(IMediator mediator, IOptions<AppSettings> appSettings)
    {
        _mediator = mediator;
        _appSettings = appSettings.Value;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> AuthenticateAsync([FromBody] CreateUserTokenCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsSuccess)
        {
            if (response.Data is not null)
            {
                response.Data.Token = BuildToken(response);
                return Ok(response.Data);
            }
            else
                return NotFound(response);
        }

        return BadRequest(response);
    }

    private string BuildToken(Response<UserDTO> userDto)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

        var claims = new Dictionary<string, object>
        {
            { "userid", userDto.Data.Id.ToString() },
            { "username", userDto.Data.UserName }
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new(ClaimTypes.Name, userDto.Data.Id.ToString()),
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _appSettings.Issuer,
            Audience = _appSettings.Audience,
            Claims = claims
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
