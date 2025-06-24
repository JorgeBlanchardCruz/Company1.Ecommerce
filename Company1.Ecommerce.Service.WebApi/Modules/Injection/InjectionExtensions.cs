using Company1.Ecommerce.Service.WebApi.Modules.GlobalException;
using Company1.Ecommerce.Transverse.Common;
using Company1.Ecommerce.Transverse.Logging;

namespace Company1.Ecommerce.Service.WebApi.Modules.Injection;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddTransient<GlobalExceptionHandler>();

        return services;
    }
}
