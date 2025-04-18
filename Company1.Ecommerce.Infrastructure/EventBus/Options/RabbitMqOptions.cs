namespace Company1.Ecommerce.Infrastructure.EventBus.Options;

public class RabbitMqOptions
{
    public string HostName { get; init; } = string.Empty;
    public string VirtualHost { get; init; } = "/";
    public int Port { get; init; } = 5672;
    public string UserName { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    //public bool UseSsl { get; set; } = false;
    //public int RetryCount { get; set; } = 5;
    //public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(5);
}
