#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async UniTask<T> Finally<T>(this Result result, Func<Result, UniTask<T>> func)
        {
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async UniTask<K> Finally<T, K>(this Result<T> result, Func<Result<T>, UniTask<K>> func)
        {
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async UniTask<K> Finally<T, K, E>(this Result<T, E> result, Func<Result<T, E>, UniTask<K>> func)
        {
            return await func(result);
        }
    }
}
#endif
