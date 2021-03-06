#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result> TapIf(this UniTask<Result> resultUniTask, bool condition, Action action)
        {
            if (condition)
                return resultUniTask.Tap(action);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T>> TapIf<T>(this UniTask<Result<T>> resultUniTask, bool condition, Action action)
        {
            if (condition)
                return resultUniTask.Tap(action);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T>> TapIf<T>(this UniTask<Result<T>> resultUniTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultUniTask.Tap(action);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T, E>> TapIf<T, E>(this UniTask<Result<T, E>> resultUniTask, bool condition, Action action)
        {
            if (condition)
                return resultUniTask.Tap(action);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T, E>> TapIf<T, E>(this UniTask<Result<T, E>> resultUniTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultUniTask.Tap(action);
            else
                return resultUniTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> TapIf<T>(this UniTask<Result<T>> resultUniTask, Func<T, bool> predicate, Action action)
        {
            Result<T> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> TapIf<T>(this UniTask<Result<T>> resultUniTask, Func<T, bool> predicate, Action<T> action)
        {
            Result<T> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> TapIf<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, bool> predicate, Action action)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> TapIf<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, bool> predicate, Action<T> action)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }
    }
}
#endif
