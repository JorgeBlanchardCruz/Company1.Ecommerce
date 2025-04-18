using Company1.Ecommerce.Application.Interface.UseCases;
using Company1.Ecommerce.Application.UseCases.Categories;
using Company1.Ecommerce.Application.UseCases.Customers;
using Company1.Ecommerce.Application.UseCases.Discounts;
using Company1.Ecommerce.Application.UseCases.Users;
using Company1.Ecommerce.Application.Validator;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Company1.Ecommerce.Application.UseCases;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ICustomersApplication, CustomersApplication>();
        services.AddScoped<IUsersApplication, UsersApplication>();
        services.AddScoped<ICategoriesApplication, CategoriesApplication>();
        services.AddScoped<IDiscountsApplication, DiscountsApplication>();

        services.AddTransient<UserDtoValidator>();
        services.AddTransient<DiscountDtoValidator>();

        return services;
    }
}
