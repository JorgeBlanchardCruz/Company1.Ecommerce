using Microsoft.AspNetCore.RateLimiting;

namespace Company1.Ecommerce.Service.WebApi.Modules.RateLimiter;

/// <summary>
/// Rate Limiter
/// </summary>
/// <remarks> 
///  * Algoritmos Rate Limiting
///1 Fixed Window
///Permite aplicar límites como "60 solicitudes por minuto". Durante cada minuto se pueden realizar 60 solicitudes.Uno cada segundo,
///pero también 60 de una sola vez.
///
///2 Sliding Window
///Piense en "60 solicitudes por minuto, con 1 solicitud por segundo".
///
///Token bucket
///Piense "te dan 100 solicitudes cada minuto". Si los hace todos en 10 segundos, tendrá que esperar I minuto antes de que se le
///permitan más solicitudes.
///
///3 Concurrency
///Es la forma más simple de limitación de velocidad. No mira el tiempo, solo el número de solicitudes simultáneas. "Permitir 10
///solicitudes simultáneas".
/// </remarks> 
public static class RateLimiterExtensions
{
    public static IServiceCollection AddRateLimiter(this IServiceCollection services, IConfiguration configuration)
    {
        var fixedWindowPolicy = "fixedWindow";
        services.AddRateLimiter(configureOptions =>
        {
            configureOptions.AddFixedWindowLimiter(policyName: fixedWindowPolicy, options =>
            {
                // En producción se debería valorar las opciones en función del hardware
                options.PermitLimit = int.Parse(configuration["RateLimiting:PermitLimit"]!); // number of requests
                options.Window = TimeSpan.FromSeconds(int.Parse(configuration["RateLimiting:Window"]!));
                options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                options.QueueLimit = int.Parse(configuration["RateLimiting:QueueLimit"]!); // requests in queue
            });

            configureOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        });

        return services;
    }

}
