#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, UniTask<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result<T, E>> Ensure<T, E>(this Result<T, E> result,
            Func<T, UniTask<bool>> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, UniTask<bool>> predicate, Func<T, string> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, UniTask<bool>> predicate, Func<T, UniTask<string>> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T>(await errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async UniTask<Result> Ensure(this Result result, Func<UniTask<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate())
                return Result.Failure(errorMessage);

            return result;
        }
    }
}
#endif
