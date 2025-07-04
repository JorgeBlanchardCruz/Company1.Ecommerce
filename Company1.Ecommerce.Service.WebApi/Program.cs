using Asp.Versioning.ApiExplorer;
using Company1.Ecommerce.Application.UseCases;
using Company1.Ecommerce.Infrastructure;
using Company1.Ecommerce.Persistence;
using Company1.Ecommerce.Service.WebApi.Modules.Authentication;
using Company1.Ecommerce.Service.WebApi.Modules.Feature;
using Company1.Ecommerce.Service.WebApi.Modules.HealthCheck;
using Company1.Ecommerce.Service.WebApi.Modules.Injection;
using Company1.Ecommerce.Service.WebApi.Modules.Middleware;
using Company1.Ecommerce.Service.WebApi.Modules.RateLimiter;
using Company1.Ecommerce.Service.WebApi.Modules.Redis;
using Company1.Ecommerce.Service.WebApi.Modules.Swagger;
using Company1.Ecommerce.Service.WebApi.Modules.Versioning;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;

#region Dependency Injection

builder.Services.AddAuth(Configuration);
builder.Services.AddVersioning();
builder.Services.AddFeature(Configuration);
builder.Services.AddSwagger();
builder.Services.AddHealthCheck(Configuration);
builder.Services.AddRedisCache(Configuration);
builder.Services.AddRateLimiter(Configuration);

builder.Services.AddInjection(Configuration);
builder.Services.AddPersistenceServices(Configuration);
builder.Services.AddInfrastructureServices(Configuration);
builder.Services.AddApplicationServices();

#endregion

#region Pipeline
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root

        foreach (var description in app.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{description.GroupName.ToUpperInvariant()}");
        }
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(FeatureExtensions.MyPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.UseRequestTimeouts();

app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.AddMiddleware();

app.Run();
#endregion

public partial class Program { };