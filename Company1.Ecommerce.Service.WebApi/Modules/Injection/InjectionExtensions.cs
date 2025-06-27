using Company1.Ecommerce.Service.WebApi.Modules.GlobalException;

namespace Company1.Ecommerce.Service.WebApi.Modules.Injection;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddTransient<GlobalExceptionHandler>();

        return services;
    }
}
