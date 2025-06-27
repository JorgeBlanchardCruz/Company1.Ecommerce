using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.UseCases.Commons.Exceptions;

public class ValidationExceptionCustom : Exception
{
    public IEnumerable<BaseError> Errors { get; }

    public ValidationExceptionCustom()
        : base("Validation failed")
    {
        Errors = [];
    }

    public ValidationExceptionCustom(IEnumerable<BaseError> errors) : this()
    {
        Errors = errors;
    }
}
