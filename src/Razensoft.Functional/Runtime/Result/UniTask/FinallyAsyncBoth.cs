#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async UniTask<T> Finally<T>(this UniTask<Result> resultUniTask, Func<Result, UniTask<T>> func)
        {
            Result result = await resultUniTask;
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async UniTask<K> Finally<T, K>(this UniTask<Result<T>> resultUniTask, Func<Result<T>, UniTask<K>> func)
        {
            Result<T> result = await resultUniTask;
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async UniTask<K> Finally<T, K, E>(this UniTask<Result<T, E>> resultUniTask,
            Func<Result<T, E>, UniTask<K>> func)
        {
            Result<T, E> result = await resultUniTask;
            return await func(result);
        }
    }
}
#endif
