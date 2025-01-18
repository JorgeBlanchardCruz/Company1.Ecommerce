using Company1.Ecommerce.Service.WebApi.Modules.Authentication;
using Company1.Ecommerce.Service.WebApi.Modules.Feature;
using Company1.Ecommerce.Service.WebApi.Modules.Injection;
using Company1.Ecommerce.Service.WebApi.Modules.Mapper;
using Company1.Ecommerce.Service.WebApi.Modules.Swagger;
using Company1.Ecommerce.Service.WebApi.Modules.Validator;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;

#region Dependency Injection

builder.Services.AddAuth(Configuration);
builder.Services.AddFeature(Configuration);
builder.Services.AddSwagger();

builder.Services.AddMapper();
builder.Services.AddValidators();

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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
    app.MapOpenApi();
}

app.UseCors(FeatureExtensions.MyPolicy);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
