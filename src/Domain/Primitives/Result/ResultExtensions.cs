using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives.Result;

public static class ResultExtensions
{
    /// <summary>
    /// The result dependes on predicate condition result.
    /// </summary>
    /// <typeparam name="T">The return type result</typeparam>
    /// <param name="result">The result</param>
    /// <param name="predicate">Predicate </param>
    /// <param name="error">Error</param>
    /// <returns>If predicate is true then success  result other wise failure.</returns>
    public static Result<T> Ensure<T>(this Result<T>result,Func<T,bool> predicate,Error error)
    {
        if (result.IsFailure)
        {
            return result;
        }
        return result.IsSuccess && predicate(result.Value) ? result : Result.Failure<T>(error);
    }

    /// <summary>
    /// Maps the result value to a new value based on the specified mapping function
    /// </summary>
    /// <typeparam name="TIn">The input result type</typeparam>
    /// <typeparam name="TOut">The output result type</typeparam>
    /// <param name="result">The Result</param>
    /// <param name="func">the mapping function.</param>
    /// <returns>THe success result with the mapped value if the current result is success result, otherwise a failure result.</returns>
    public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func)
        => result.IsSuccess ? func(result.Value) : Result.Failure<TOut>(result.Error);

    /// <summary>
    /// Bind to the result of the funciton and retures it.
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <param name="result"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static async Task<Result> Bind<TIn>(this Result<TIn> result,Func<TIn,Task<Result>> func)
        => result.IsSuccess? await func(result.Value):Result.Failure(result.Error);

    public static async Task<T> Match<T>(this Task<Result> resulTask, Func<T> onSuccess, Func<Error, T> onFailure)
    {
        Result result = await resulTask;
        return result.IsSuccess ? onSuccess() : onFailure(result.Error);
    }

}
