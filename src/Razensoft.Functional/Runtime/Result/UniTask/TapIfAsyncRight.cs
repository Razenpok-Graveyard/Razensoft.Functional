#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
#if !NET40
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result> TapIf(this Result result, bool condition, Func<UniTask> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return UniTask.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<UniTask> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return UniTask.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<T, UniTask> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return UniTask.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<UniTask> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return UniTask.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<T, UniTask> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return UniTask.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<UniTask> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return UniTask.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, UniTask> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return UniTask.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<UniTask> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return UniTask.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static UniTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, UniTask> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return UniTask.FromResult(result);
        }
    }
}
#endif
#endif
