#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async UniTask<Result<T>> Check<T>(this Result<T> result, Func<T, UniTask<Result>> func)
        {
            return await result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async UniTask<Result<T>> Check<T, K>(this Result<T> result, Func<T, UniTask<Result<K>>> func)
        {
            return await result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async UniTask<Result<T, E>> Check<T, K, E>(this Result<T, E> result, Func<T, UniTask<Result<K, E>>> func)
        {
            return await result.Bind(func).Map(_ => result.Value);
        }
    }
}
#endif