#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> OnFailure<T>(this Result<T> result, Func<UniTask> func)
        {
            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<UniTask> func)
        {
            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result> OnFailure(this Result result, Func<UniTask> func)
        {
            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> OnFailure<T>(this Result<T> result, Func<string, UniTask> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<E, UniTask> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }
    }
}
#endif
