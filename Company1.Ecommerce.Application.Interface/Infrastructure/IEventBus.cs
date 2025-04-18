namespace Company1.Ecommerce.Application.Interface.Infrastructure;

public interface IEventBus
{
    void Publish<T>(T @event) where T : class;

}
