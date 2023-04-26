using Domain.Primitives;
using FluentValidation.Results;

namespace Application.Exceptions;

/// <summary>
/// Represents an exception that occures when a validation fails.
/// </summary>
public sealed class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : base("One or more validation failures has occurred.")
        => Errors = failures.Distinct()
        .Select(failure => new Error(failure.ErrorCode, failure.ErrorMessage))
        .ToArray();


    /// <summary>
    /// Get The errors.
    /// </summary>
    public IReadOnlyCollection<Error> Errors { get; }
}
