using Company1.Ecommerce.Application.Interface.Presentation;
using Company1.Ecommerce.Service.WebApi.Modules.GlobalException;
using Company1.Ecommerce.Service.WebApi.Services;

namespace Company1.Ecommerce.Service.WebApi.Modules.Injection;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddTransient<GlobalExceptionHandler>();
        services.AddScoped<ICurrentUser, CurrentUser>();

        return services;
    }
}
