using Company1.Ecommerce.Application.Interface.UseCases;
using Company1.Ecommerce.Application.UseCases.Categories;
using Company1.Ecommerce.Application.UseCases.Customers;
using Company1.Ecommerce.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Company1.Ecommerce.Application.UseCases;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomersApplication, CustomersApplication>();
        services.AddScoped<IUsersApplication, UsersApplication>();
        services.AddScoped<ICategoriesApplication, CategoriesApplication>();

        return services;
    }
}
