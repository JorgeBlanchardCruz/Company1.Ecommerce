﻿using FluentValidation.Results;

namespace Company1.Ecommerce.Transverse.Common;

public class ResponseGeneric<T>
{
    public T Data { get; set; } = default!;
    public bool IsSuccess { get; set; } = false;
    public string Message { get; set; } = default!;
    public IEnumerable<ValidationFailure> Errors { get; set; } = default!;
}
