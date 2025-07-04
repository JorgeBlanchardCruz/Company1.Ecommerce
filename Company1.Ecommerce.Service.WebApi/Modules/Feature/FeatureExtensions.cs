﻿using Humanizer;
using Microsoft.AspNetCore.Http.Timeouts;
using System.Text.Json.Serialization;

namespace Company1.Ecommerce.Service.WebApi.Modules.Feature;

public static class FeatureExtensions
{
    public const string MyPolicy = "policyApiEcommerce";

    public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();

        services.AddCors(options => options.AddPolicy(MyPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"]!)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin()
            ));

        services.AddControllers().AddJsonOptions(options =>
        {
            var enumConverter = new JsonStringEnumConverter();
            options.JsonSerializerOptions.Converters.Add(enumConverter);
        });

        services.AddRequestTimeouts(options => {
            options.DefaultPolicy = new RequestTimeoutPolicy { Timeout = TimeSpan.FromMilliseconds(1500) };
            options.AddPolicy("CustomPolicy", TimeSpan.FromMilliseconds(1500));
        });

        return services;
    }
}
