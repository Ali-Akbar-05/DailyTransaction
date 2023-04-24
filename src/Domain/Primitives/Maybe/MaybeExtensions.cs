using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives.Maybe;

public static class MaybeExtensions
{
    /// <summary>
    /// Binds to the result of the function and return it
    /// </summary>
    /// <typeparam name="TIn">The input type</typeparam>
    /// <typeparam name="TOut"> The output result type</typeparam>
    /// <param name="maybe"> the result</param>
    /// <param name="func">the bind function</param>
    /// <returns>the success result with the bound value if the current resutl is a success result, other wise a failure result </returns>
    public static async Task<Maybe<TOut>> Bind<TIn, TOut>(this Maybe<TIn> maybe, Func<TIn, Task<Maybe<TOut>>> func) =>
        maybe.HasValue ? await func(maybe.Value) : Maybe<TOut>.None;


    /// <summary>
    /// Matches to the corresponding founctions base on existence of the value
    /// </summary>
    /// <typeparam name="TIn">The input type</typeparam>
    /// <typeparam name="TOut">The output type</typeparam>
    /// <param name="resultTask">the may be tasks</param>
    /// <param name="onSuccess">On success function</param>
    /// <param name="onFailure">On failure functions</param>
    /// <returns>The result on-success functin if the maybe has a value, other wise   Failure resutl function</returns>
    public static async Task<TOut> Match<TIn, TOut>(this Task<Maybe<TIn>> resultTask,Func<TIn,TOut>onSuccess,Func<TOut> onFailure)
    {
        Maybe<TIn> maybe = await resultTask;
        return maybe.HasValue ? onSuccess(maybe.Value) : onFailure();
    }
}
