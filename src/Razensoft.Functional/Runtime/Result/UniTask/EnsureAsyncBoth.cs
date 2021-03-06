#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result<T>> Ensure<T>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask<bool>> predicate, string errorMessage)
        {
            Result<T> result = await resultUniTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result<T, E>> Ensure<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, UniTask<bool>> predicate, E error)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result<T>> Ensure<T>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask<bool>> predicate, Func<T, string> errorPredicate)
        {
            Result<T> result = await resultUniTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result<T>> Ensure<T>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask<bool>> predicate, Func<T, UniTask<string>> errorPredicate)
        {
            Result<T> result = await resultUniTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T>(await errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result> Ensure(this UniTask<Result> resultUniTask, Func<UniTask<bool>> predicate, string errorMessage)
        {
            Result result = await resultUniTask;

            if (result.IsFailure)
                return result;

            if (!await predicate())
                return Result.Failure(errorMessage);

            return result;
        }
    }
}
#endif
