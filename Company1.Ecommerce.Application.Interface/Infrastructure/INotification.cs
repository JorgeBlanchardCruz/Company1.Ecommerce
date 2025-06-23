namespace Company1.Ecommerce.Application.Interface.Infrastructure;

public interface INotification
{
    Task<bool> SendEmailAsync(
        string subject,
        string body,
        CancellationToken cancellationToken = new());
}
