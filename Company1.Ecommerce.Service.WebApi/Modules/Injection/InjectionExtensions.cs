using Company1.Ecommerce.Application.Interface;
using Company1.Ecommerce.Application.Main;
using Company1.Ecommerce.Domain.Core;
using Company1.Ecommerce.Domain.Interface;
using Company1.Ecommerce.Infraestructure.Data;
using Company1.Ecommerce.Infrastructure.Interface;
using Company1.Ecommerce.Infrastructure.Repository;
using Company1.Ecommerce.Transverse.Common;
using Company1.Ecommerce.Transverse.Logging;

namespace Company1.Ecommerce.Service.WebApi.Modules.Injection;

public static class InjectionExtensions
{
    public static void AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        services.AddSingleton<IConnectionFactory, ConnectionFactory>();
        services.AddScoped<ICustomersApplication, CustomersApplication>();
        services.AddScoped<ICustomersDomain, CustomersDomain>();
        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<IUsersApplication, UsersApplication>();
        services.AddScoped<IUsersDomain, UsersDomain>();
        services.AddScoped<IUsersRepository, UsersRepository>();
    }
}
