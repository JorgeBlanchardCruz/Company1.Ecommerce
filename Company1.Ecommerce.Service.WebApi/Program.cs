using Company1.Ecommerce.Service.WebApi.Modules.Authentication;
using Company1.Ecommerce.Service.WebApi.Modules.Feature;
using Company1.Ecommerce.Service.WebApi.Modules.HealthCheck;
using Company1.Ecommerce.Service.WebApi.Modules.Injection;
using Company1.Ecommerce.Service.WebApi.Modules.Mapper;
using Company1.Ecommerce.Service.WebApi.Modules.Swagger;
using Company1.Ecommerce.Service.WebApi.Modules.Validator;
using Company1.Ecommerce.Service.WebApi.Modules.Versioning;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;

#region Dependency Injection

builder.Services.AddAuth(Configuration);
builder.Services.AddVersioning();
builder.Services.AddFeature(Configuration);
builder.Services.AddSwagger();

builder.Services.AddMapper();
builder.Services.AddValidators();
builder.Services.AddHealthCheck(Configuration);

builder.Services.AddInjection(Configuration);

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

app.UseCors(FeatureExtensions.MyPolicy);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
//comprueba http://localhost:5285/health
//visita http://localhost:5285/healthchecks-ui#/healthchecks para el UI de healthchecks

app.Run();
#endregion

public partial class Program { };
