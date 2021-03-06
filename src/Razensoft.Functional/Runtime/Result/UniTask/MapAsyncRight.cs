#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result<K, E>> Map<T, K, E>(this Result<T, E> result, Func<T, UniTask<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await func(result.Value);

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result<K>> Map<T, K>(this Result<T> result, Func<T, UniTask<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await func(result.Value);

            return Result.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result<K>> Map<K>(this Result result, Func<UniTask<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await func();

            return Result.Success(value);
        }
    }
}
#endif
