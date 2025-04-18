namespace Company1.Ecommerce.Service.WebApi.Modules.Feature;

public static class FeatureExtensions
{
    public const string MyPolicy = "policyApiEcommerce";

    public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();

        services.AddCors(options => options.AddPolicy(MyPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"]!)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin()
            ));



        return services;
    }
}
