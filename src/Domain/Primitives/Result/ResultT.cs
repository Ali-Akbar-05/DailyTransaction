namespace Domain.Primitives.Result;

/// <summary>
/// represent the result of some operation, with status information
/// and possibly a value and an error.
/// </summary>
/// <typeparam name="TValue">The result value type.</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue _value;

    /// <summary>
    /// initialize a new instance of the <see cref="Result{TValue}"/>
    /// </summary>
    /// <param name="value">the result value type</param>
    /// <param name="isSuccess">result status</param>
    /// <param name="error">Error status</param>
    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error)
        => _value = value;

    /// <summary>
    /// Get the result is successful or Error.
    /// </summary>
    ///<returns>The result value if the result is successful</returns>
    ///<exception cref="InvalidOperationException" when  <see cref="Result.IsFailure"/> is true
    public TValue Value => IsSuccess ?
        _value
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator Result<TValue>(TValue value) => Success(value);
}
