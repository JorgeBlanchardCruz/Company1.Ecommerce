using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Application.Interface.UseCases;
using Company1.Ecommerce.Application.UseCases;
using Company1.Ecommerce.Persistence.Data;
using Company1.Ecommerce.Persistence.Repository;
using Company1.Ecommerce.Transverse.Common;
using Company1.Ecommerce.Transverse.Logging;

namespace Company1.Ecommerce.Service.WebApi.Modules.Injection;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddSingleton<DapperContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<ICustomersApplication, CustomersApplication>();

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IUsersApplication, UsersApplication>();

        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<ICategoriesApplication, CategoriesApplication>();

        return services;
    }
}
