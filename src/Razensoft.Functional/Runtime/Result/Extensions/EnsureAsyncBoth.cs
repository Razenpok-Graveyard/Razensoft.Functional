using System;
using System.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, string errorMessage)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Result<T, E>> Ensure<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<bool>> predicate, E error)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, Func<T, string> errorPredicate)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, Func<T, Task<string>> errorPredicate)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T>(await errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Result> Ensure(this Task<Result> resultTask, Func<Task<bool>> predicate, string errorMessage)
        {
            Result result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate().DefaultAwait())
                return Result.Failure(errorMessage);

            return result;
        }
    }
}
