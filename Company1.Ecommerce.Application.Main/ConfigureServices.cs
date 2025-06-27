using Company1.Ecommerce.Application.Interface.UseCases;
using Company1.Ecommerce.Application.UseCases.Categories;
using Company1.Ecommerce.Application.UseCases.Commons.Behaviors;
using Company1.Ecommerce.Application.UseCases.Discounts;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Company1.Ecommerce.Application.UseCases;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });


        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ICategoriesApplication, CategoriesApplication>();
        services.AddScoped<IDiscountsApplication, DiscountsApplication>();

        return services;
    }
}
