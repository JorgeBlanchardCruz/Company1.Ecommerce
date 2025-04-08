namespace Company1.Ecommerce.Service.WebApi.Modules.HealthCheck;

public static class HealthCheckExtensions
{
    public static void AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddCheck<HealthCheckCustom>("Health Check Custom", tags: ["custom"])
            .AddSqlServer(configuration.GetConnectionString("NorthwindConnection")!, tags: ["database"])
            .AddRedis(configuration.GetConnectionString("RedisConnection")!, tags: ["cache"]);

        services
            .AddHealthChecksUI()
            .AddInMemoryStorage();

    }
}
