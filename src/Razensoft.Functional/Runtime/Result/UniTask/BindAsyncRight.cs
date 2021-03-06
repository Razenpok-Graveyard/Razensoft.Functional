#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UniTask<Result<K, E>> Bind<T, K, E>(this Result<T, E> result, Func<T, UniTask<Result<K, E>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error).AsCompletedUniTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UniTask<Result<K>> Bind<T, K>(this Result<T> result, Func<T, UniTask<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error).AsCompletedUniTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UniTask<Result<K>> Bind<K>(this Result result, Func<UniTask<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error).AsCompletedUniTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UniTask<Result> Bind<T>(this Result<T> result, Func<T, UniTask<Result>> func)
        {
            if (result.IsFailure)
                return Result.Failure(result.Error).AsCompletedUniTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UniTask<Result> Bind(this Result result, Func<UniTask<Result>> func)
        {
            if (result.IsFailure)
                return result.AsCompletedUniTask();

            return func();
        }
    }
}
#endif