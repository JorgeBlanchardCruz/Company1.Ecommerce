using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Persistence.Context;
using Company1.Ecommerce.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Company1.Ecommerce.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<DapperContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();

        return services;
    }
}
