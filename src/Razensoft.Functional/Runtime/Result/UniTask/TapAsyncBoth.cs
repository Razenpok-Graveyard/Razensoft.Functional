#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result> Tap(this UniTask<Result> resultUniTask, Func<UniTask> func)
        {
            Result result = await resultUniTask;

            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> Tap<T>(this UniTask<Result<T>> resultUniTask, Func<UniTask> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> Tap<T>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsSuccess)
                await func(result.Value);

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> Tap<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<UniTask> func)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> Tap<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, UniTask> func)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsSuccess)
                await func(result.Value);

            return result;
        }
    }
}
#endif
