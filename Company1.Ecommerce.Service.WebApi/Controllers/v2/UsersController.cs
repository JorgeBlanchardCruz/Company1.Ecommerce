using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface;
using Company1.Ecommerce.Service.WebApi.Helpers;
using Company1.Ecommerce.Transverse.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company1.Ecommerce.Service.WebApi.Controllers.v2;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
[ApiVersion("2.0")]
public class UsersController : Controller
{
    private readonly IUsersApplication _userApplication;
    private readonly AppSettings _appSettings;

    public UsersController(IUsersApplication userApplication, IOptions<AppSettings> appSettings)
    {
        _userApplication = userApplication;
        _appSettings = appSettings.Value;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Authenticate([FromBody] UsersDTO userDto)
    {
        var response = _userApplication.Authenticate(userDto.UserName, userDto.Password);
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

    private string BuildToken(Response<UsersDTO> userDto)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new(ClaimTypes.Name, userDto.Data.Id.ToString()),
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _appSettings.Issuer,
            Audience = _appSettings.Audience
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
