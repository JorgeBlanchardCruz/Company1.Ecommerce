using Company1.Ecommerce.Service.WebApi.Modules.GlobalException;

namespace Company1.Ecommerce.Service.WebApi.Modules.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
    {   
        app.UseMiddleware<GlobalExceptionHandler>();
        return app;
    }
}
