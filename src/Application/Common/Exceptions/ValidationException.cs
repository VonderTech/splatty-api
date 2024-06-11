using FluentValidation.Results;

namespace Application.Common.Exceptions;

/// <summary>
///     Represents a validation exception that is thrown when one or more validation failures occur.
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ValidationException" /> class with a default
    ///     message.
    /// </summary>
    private ValidationException()
        : base("One or more validation failures have occurred.") { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ValidationException" /> class with a collection of
    ///     validation failures.
    /// </summary>
    /// <param name="failures">The collection of validation failures.</param>
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    /// <summary>
    ///     Gets the dictionary of validation errors.
    ///     The key is the property name and the value is an array of error messages.
    /// </summary>
    public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
}
