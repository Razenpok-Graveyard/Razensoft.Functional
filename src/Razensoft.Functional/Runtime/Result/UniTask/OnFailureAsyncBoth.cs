#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> OnFailure<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<UniTask> func)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> OnFailure<T>(this UniTask<Result<T>> resultUniTask, Func<UniTask> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result> OnFailure(this UniTask<Result> resultUniTask, Func<UniTask> func)
        {
            Result result = await resultUniTask;

            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> OnFailure<T>(this UniTask<Result<T>> resultUniTask, Func<string, UniTask> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> OnFailure<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<E, UniTask> func)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }
    }
}
#endif
