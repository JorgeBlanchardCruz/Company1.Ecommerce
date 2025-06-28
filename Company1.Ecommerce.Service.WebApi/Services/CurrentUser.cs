using Company1.Ecommerce.Application.Interface.Presentation;
using Company1.Ecommerce.Application.UseCases.Commons.Constants;

namespace Company1.Ecommerce.Service.WebApi.Services;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirst("userid")?.Value ?? GlobalConstant.DefaultUserId;
    public string? UserName => _httpContextAccessor.HttpContext?.User?.FindFirst("username")?.Value ?? GlobalConstant.DefaultUserId;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

}
