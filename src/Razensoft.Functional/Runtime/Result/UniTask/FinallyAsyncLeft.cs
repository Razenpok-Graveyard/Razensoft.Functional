#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async UniTask<T> Finally<T>(this UniTask<Result> resultUniTask, Func<Result, T> func)
        {
            Result result = await resultUniTask;
            return result.Finally(func);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async UniTask<K> Finally<T, K>(this UniTask<Result<T>> resultUniTask, Func<Result<T>, K> func)
        {
            Result<T> result = await resultUniTask;
            return result.Finally(func);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async UniTask<K> Finally<T, K, E>(this UniTask<Result<T, E>> resultUniTask,
            Func<Result<T, E>, K> func)
        {
            Result<T, E> result = await resultUniTask;
            return result.Finally(func);
        }
    }
}
#endif
