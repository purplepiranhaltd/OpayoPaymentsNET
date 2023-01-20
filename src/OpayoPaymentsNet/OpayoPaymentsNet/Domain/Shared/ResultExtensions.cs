using Microsoft.VisualBasic;

namespace OpayoPaymentsNet.Domain.Shared;

public static class ResultExtensions
{
    public static Result<T> Ensure<T>(
        this Result<T> result,
        Func<T, bool> predicate,
        Error error)
    {
        if (result.IsFailure)
        {
            return result;
        }

        return predicate(result.Value) ?
            result :
            Result.Failure<T>(error);
    }

    public static Result<TOut> Map<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> mappingFunc)
    {
        return result.IsSuccess ?
            Result.Success(mappingFunc(result.Value)) :
            Result.Failure<TOut>(result.Error);
    }

    ////public static Result<T> OnSuccess<T>(
    ////    this Result<T> result, Action<T> action)
    ////{
    ////    if (!result.IsFailure)
    ////        action(result.Value);

    ////    return result;
    ////}

    ////public static async Task<Result<T>> OnSuccessAsync<T>(
    ////    this Result<T> result, Func<T, Task> function)
    ////{
    ////    if (!result.IsFailure)
    ////    {
    ////        await function(result.Value);
    ////    }

    ////    return result;
    ////}

    ////public static Result<T> OnValidationFailure<T>(
    ////    this Result<T> result, 
    ////    Action<ValidationResult<T>> action
    ////    )
    ////{
    ////    if (result.IsFailure && result is ValidationResult<T> validationResult)
    ////        action(validationResult);

    ////    return result;
    ////}

    ////public static Result<T> OnNonValidationFailure<T>(
    ////    this Result<T> result,
    ////    Action<Result<T>> action
    ////    )
    ////{
    ////    if (result.IsFailure && result is not ValidationResult<T>)
    ////        action(result);

    ////    return result;
    ////}

    ////public static Result<T> OnAnyFailure<T>(
    ////    this Result<T> result,
    ////    Action<Result<T>> action
    ////    )
    ////{
    ////    if (result.IsFailure)
    ////        action(result);

    ////    return result;
    ////}

    ////public static void Finally<T>(
    ////    this Result<T> result,
    ////    Action<Result<T>> action )
    ////{
    ////    action(result);
    ////}
}
