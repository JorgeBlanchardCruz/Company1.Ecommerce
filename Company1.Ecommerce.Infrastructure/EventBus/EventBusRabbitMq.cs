using Company1.Ecommerce.Application.Interface.Infrastructure;
using MassTransit;

namespace Company1.Ecommerce.Infrastructure.EventBus;

public class EventBusRabbitMq : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventBusRabbitMq(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async void Publish<T>(T @event) where T : class
    {
        await _publishEndpoint.Publish(@event);
    }
}
