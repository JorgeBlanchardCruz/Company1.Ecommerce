using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Company1.Ecommerce.Service.WebApi.Modules.HealthCheck;

public class HealthCheckCustom : IHealthCheck
{
    private readonly Random _random = new();

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        // Simulate a random response time
        // Should be replaced with a real health check, for example, a messagenqueue check, disk space check, distributed cache check, etc.
        var responseTime = _random.Next(1, 300);

        if (responseTime < 100)
        {
            return Task.FromResult(HealthCheckResult.Healthy("The check indicates a healthy result."));
        }
        else if (responseTime < 200)
        {
            return Task.FromResult(HealthCheckResult.Degraded("The check indicates a degraded result."));
        }
        else
        {
            return Task.FromResult(HealthCheckResult.Unhealthy("The check indicates an unhealthy result."));
        }
    }
}
