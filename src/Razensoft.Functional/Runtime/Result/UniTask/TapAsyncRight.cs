#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result> Tap(this Result result, Func<UniTask> func)
        {
            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> Tap<T>(this Result<T> result, Func<UniTask> func)
        {
            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> Tap<T>(this Result<T> result, Func<T, UniTask> func)
        {
            if (result.IsSuccess)
                await func(result.Value);

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<UniTask> func)
        {
            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<T, UniTask> func)
        {
            if (result.IsSuccess)
                await func(result.Value);

            return result;
        }
    }
}
#endif
