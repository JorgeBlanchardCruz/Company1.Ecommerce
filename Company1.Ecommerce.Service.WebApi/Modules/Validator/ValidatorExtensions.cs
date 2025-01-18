using Company1.Ecommerce.Application.Validator;

namespace Company1.Ecommerce.Service.WebApi.Modules.Validator;

public static class ValidatorExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddTransient<UsersDtoValidator>();
    }
}
