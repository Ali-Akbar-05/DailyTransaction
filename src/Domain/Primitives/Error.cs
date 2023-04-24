using Domain.Core;

namespace Domain.Primitives;

public sealed class Error : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message</param>
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    /// <summary>
    /// See the Error code
    /// </summary>
    public string Code { get; }
    /// <summary>
    /// See the error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the empty error instance.
    /// </summary>
    internal static Error None => new Error(string.Empty, string.Empty);

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return Message;
    }
}
