using Company1.Ecommerce.Domain.Events;
using MassTransit;
using System.Text.Json;

namespace Company1.Ecommerce.ConsoleApp.Consumer;

public class DiscountCreatedConsumer : IConsumer<DiscountCreatedEvent>
{
    public async Task Consume(ConsumeContext<DiscountCreatedEvent> context)
    {
        var jsonMessage = JsonSerializer.Serialize(context.Message);
        await Console.Out.WriteLineAsync($"Message from producer: {jsonMessage}");
    }
}
