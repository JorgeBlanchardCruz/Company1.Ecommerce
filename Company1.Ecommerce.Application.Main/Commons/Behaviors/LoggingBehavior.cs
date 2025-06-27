using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Company1.Ecommerce.Application.UseCases.Commons.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //PRE
        _logger.LogInformation("Handling request: {RequestName} {@request}", typeof(TRequest).Name, JsonSerializer.Serialize(request));

        var response = await next(cancellationToken);

        //POST
        _logger.LogInformation("Handled request: {RequestName} {@response}", typeof(TRequest).Name, JsonSerializer.Serialize(response));

        return response;
    }
}
