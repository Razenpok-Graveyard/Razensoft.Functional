#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> OnFailure<T>(this UniTask<Result<T>> resultUniTask, Action action)
        {
            Result<T> result = await resultUniTask;
            return result.OnFailure(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result> OnFailure(this UniTask<Result> resultUniTask, Action action)
        {
            Result result = await resultUniTask;
            return result.OnFailure(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T>> OnFailure<T>(this UniTask<Result<T>> resultUniTask, Action<string> action)
        {
            Result<T> result = await resultUniTask;
            return result.OnFailure(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result<T, E>> OnFailure<T, E>(this UniTask<Result<T, E>> resultUniTask, Action<E> action)
        {
            Result<T, E> result = await resultUniTask;
            return result.OnFailure(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async UniTask<Result> OnFailure(this UniTask<Result> resultUniTask, Action<string> action)
        {
            Result result = await resultUniTask;
            return result.OnFailure(action);
        }
    }
}
#endif
