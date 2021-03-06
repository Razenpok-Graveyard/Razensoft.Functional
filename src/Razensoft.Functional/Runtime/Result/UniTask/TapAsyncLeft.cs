#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result> Tap(this UniTask<Result> resultUniTask, Action action)
        {
            Result result = await resultUniTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> Tap<T>(this UniTask<Result<T>> resultUniTask, Action action)
        {
            Result<T> result = await resultUniTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> Tap<T>(this UniTask<Result<T>> resultUniTask, Action<T> action)
        {
            Result<T> result = await resultUniTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> Tap<T, E>(this UniTask<Result<T, E>> resultUniTask, Action action)
        {
            Result<T, E> result = await resultUniTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> Tap<T, E>(this UniTask<Result<T, E>> resultUniTask, Action<T> action)
        {
            Result<T, E> result = await resultUniTask;
            return result.Tap(action);
        }
    }
}
#endif
