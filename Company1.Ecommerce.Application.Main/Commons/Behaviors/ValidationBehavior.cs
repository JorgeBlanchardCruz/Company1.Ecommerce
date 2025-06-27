using Company1.Ecommerce.Application.UseCases.Commons.Exceptions;
using Company1.Ecommerce.Transverse.Common;
using FluentValidation;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Commons.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.Where(r => r.Errors.Any()).SelectMany(r => r.Errors)
                .Select(e => new BaseError { PropertyMessage = e.PropertyName, ErrorMessage = e.ErrorMessage})
                .ToList();

            if (failures.Any())
                throw new ValidationExceptionCustom(failures);
        }

        return await next(cancellationToken);
    }
}
