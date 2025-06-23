using Company1.Ecommerce.Application.Interface.Infrastructure;
using Company1.Ecommerce.Infrastructure.EventBus;
using Company1.Ecommerce.Infrastructure.EventBus.Options;
using Company1.Ecommerce.Infrastructure.Notification;
using Company1.Ecommerce.Infrastructure.Notification.Options;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SendGrid.Extensions.DependencyInjection;

namespace Company1.Ecommerce.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register RabbitMQ
        services.ConfigureOptions<RabbitMqOptionsSetup>();
        services.AddScoped<IEventBus, EventBusRabbitMq>();
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                RabbitMqOptions options = services.BuildServiceProvider()
                    .GetRequiredService<IOptions<RabbitMqOptions>>()
                    .Value;

                cfg.Host(options.HostName, options.VirtualHost, h =>
                {
                    h.Username(options.UserName);
                    h.Password(options.Password);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        // Register Sendgrid
        services.AddScoped<INotification, NotificationSendgrid>();
        services.ConfigureOptions<SendgridOptionsSetup>();
        SendgridOptions? sendgridOptions = services.BuildServiceProvider()
            .GetRequiredService<IOptions<SendgridOptions>>()
            .Value;

        services.AddSendGrid(options =>
        {
            options.ApiKey = sendgridOptions.ApiKey;
        });

        return services;
    }
}
