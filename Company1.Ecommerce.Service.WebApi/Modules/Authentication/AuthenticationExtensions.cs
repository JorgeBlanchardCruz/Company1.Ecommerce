using Company1.Ecommerce.Service.WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Company1.Ecommerce.Service.WebApi.Modules.Authentication;

public static class AuthenticationExtensions
{
    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure JWT authentication
        var appSettingsSection = configuration.GetSection("Config");
        services.Configure<AppSettings>(appSettingsSection);

        var appSettings = appSettingsSection.Get<AppSettings>();
        var secretKey = System.Text.Encoding.ASCII.GetBytes(appSettings!.SecretKey);
        var issuer = appSettings.Issuer;
        var audience = appSettings.Audience;

        services.AddHttpContextAccessor();

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    var userId = int.Parse(context.Principal!.Identity!.Name!);

                    return Task.CompletedTask;
                },

                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Append("Token-Expired", "true");
                    }

                    return Task.CompletedTask;
                }
            };

            x.RequireHttpsMetadata = false;
            x.SaveToken = false;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}
