namespace Company1.Ecommerce.Infrastructure.Notification.Options;

public class SendgridOptions
{
    public string ApiKey { get; init; } = default!;
    public string FromEmail { get; init; } = default!;
    public string FromUser { get; init; } = default!;
    public bool SandboxMode { get; init; } = false;
    public string ToAddress { get; init; } = default!;
    public string ToName { get; init; } = default!;
}
