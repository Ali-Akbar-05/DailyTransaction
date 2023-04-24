namespace Domain.Primitives.Result;

public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with default parameter.
    /// </summary>
    /// <param name="isSuccess">Result is Success or not.</param>
    /// <param name="error">Occoured error</param>
    /// <exception cref="InvalidOperationException"></exception>
    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }
        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }
        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Its indicate output is a successfule result
    /// </summary>
    public bool IsSuccess { get; }
    /// <summary>
    /// Output have a fault
    /// </summary>
    public bool IsFailure { get; }
    /// <summary>
    /// Occured error.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Result Success() => new Result(true, Error.None);

    /// <summary>
    /// Returns a success <see cref="Result{TValue}"/> with the specified value.
    /// </summary>
    /// <typeparam name="TValue">Result type</typeparam>
    /// <param name="value">result value</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the success flag set.</returns>
    public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, Error.None);

    /// <summary>
    /// Create n new <see cref="Result{TValue}"/> with the specified nullable value and the specified error.
    /// </summary>
    /// <typeparam name="TValue">The result type</typeparam>
    /// <param name="value">The result value</param>
    /// <param name="error">The error in case the value is null</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified value or an error.</returns>
    public static Result<TValue> Create<TValue>(TValue value, Error error)
        where TValue : class
        => value is null ? Failure<TValue>(error) : Success(value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Result Failure(Error error) => new Result(false, error);

    /// <summary>
    /// Returna failure <see cref="Result{TValue}"/> with the specified error.
    /// </summary>
    /// <typeparam name="TValue">The result type</typeparam>
    /// <param name="error">Error</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified error and failure flag set.</returns>
    ///<remarks>We're purposefully ignoring the nullable assigment here because the API will never allow it to be accessed.
    ///The value is assces through a method that will throw an exception.
    ///if the result is failure result.
    ///</remarks>
    public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default!, false, error);

    /// <summary>
    /// Returns the first failure from the specified <paramref name="result"/>
    /// if there are no failure then return a successful result.
    /// </summary>
    /// <param name="result">the result array</param>
    /// <returns>The first failure from the specified <paramref name="result"/></returns>
    public static Result FirstFailureOrSuccess(params Result[] result)
    {
        foreach (Result result1 in result)
        {
            if (result1.IsFailure)
            {
                return result1;
            }
        }
        return Success();
    }



}
