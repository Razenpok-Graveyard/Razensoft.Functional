#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async UniTask<Result<T>> Check<T>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask<Result>> func)
        {
            Result<T> result = await resultUniTask;
            return await result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async UniTask<Result<T>> Check<T, K>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask<Result<K>>> func)
        {
            Result<T> result = await resultUniTask;
            return await result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async UniTask<Result<T, E>> Check<T, K, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, UniTask<Result<K, E>>> func)
        {
            Result<T, E> result = await resultUniTask;
            return await result.Bind(func).Map(_ => result.Value);
        }
    }
}
#endif