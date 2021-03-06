#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result> TapIf(this UniTask<Result> resultUniTask, bool condition, Func<UniTask> func)
        {
            if (condition)
                return resultUniTask.Tap(func);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T>> TapIf<T>(this UniTask<Result<T>> resultUniTask, bool condition, Func<UniTask> func)
        {
            if (condition)
                return resultUniTask.Tap(func);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T>> TapIf<T>(this UniTask<Result<T>> resultUniTask, bool condition, Func<T, UniTask> func)
        {
            if (condition)
                return resultUniTask.Tap(func);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T, E>> TapIf<T, E>(this UniTask<Result<T, E>> resultUniTask, bool condition, Func<UniTask> func)
        {
            if (condition)
                return resultUniTask.Tap(func);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T, E>> TapIf<T, E>(this UniTask<Result<T, E>> resultUniTask, bool condition, Func<T, UniTask> func)
        {
            if (condition)
                return resultUniTask.Tap(func);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> TapIf<T>(this UniTask<Result<T>> resultUniTask, Func<T, bool> predicate, Func<UniTask> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> TapIf<T>(this UniTask<Result<T>> resultUniTask, Func<T, bool> predicate, Func<T, UniTask> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> TapIf<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, bool> predicate, Func<UniTask> func)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> TapIf<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, bool> predicate, Func<T, UniTask> func)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func);
            else
                return result;
        }
    }
}
#endif
