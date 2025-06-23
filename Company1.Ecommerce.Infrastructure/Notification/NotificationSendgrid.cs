using Company1.Ecommerce.Application.Interface.Infrastructure;
using Company1.Ecommerce.Infrastructure.Notification.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Company1.Ecommerce.Infrastructure.Notification;

public class NotificationSendgrid : INotification
{
    private readonly ILogger<NotificationSendgrid> _logger;
    private readonly SendgridOptions _options;
    private readonly ISendGridClient _sendgridClient;

    public NotificationSendgrid(ILogger<NotificationSendgrid> logger, IOptions<SendgridOptions> options, ISendGridClient sendgridClient)
    {
        _logger = logger;
        _options = options.Value;
        _sendgridClient = sendgridClient;
    }

    public async Task<bool> SendEmailAsync(string subject, string body, CancellationToken cancellationToken = default)
    {
        try
        {
            SendGridMessage message = BuildMessage(subject, body);
            var response = await _sendgridClient.SendEmailAsync(message, cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Email sent successfully to {ToAddress} with subject: {Subject}", _options.ToAddress, subject);
                return true;
            }
            else
            {
                _logger.LogError("Failed to send email. Status Code: {StatusCode}, Body: {Body}", response.StatusCode, await response.Body.ReadAsStringAsync(cancellationToken));
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while sending email to {ToAddress} with subject: {Subject}", _options.ToAddress, subject);
            return false;
        }
    }

    private SendGridMessage BuildMessage(string subject, string body)
    {
        var message = new SendGridMessage
        {
            From = new EmailAddress(_options.FromEmail, _options.FromUser),
            Subject = subject,
        };

        message.AddContent(MimeType.Html, body);
        message.AddTo(new EmailAddress(_options.ToAddress, _options.ToName));

        if (_options.SandboxMode)
        {
            message.MailSettings = new MailSettings
            {
                SandboxMode = new SandboxMode
                {
                    Enable = true
                }
            };
        }

        return message;
    }
}
