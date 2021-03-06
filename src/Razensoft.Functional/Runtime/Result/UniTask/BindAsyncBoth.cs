#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result<K, E>> Bind<T, K, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, UniTask<Result<K, E>>> func)
        {
            Result<T, E> result = await resultUniTask;
            return await result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result<K>> Bind<T, K>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask<Result<K>>> func)
        {
            Result<T> result = await resultUniTask;
            return await result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result<K>> Bind<K>(this UniTask<Result> resultUniTask, Func<UniTask<Result<K>>> func)
        {
            Result result = await resultUniTask;
            return await result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result> Bind<T>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask<Result>> func)
        {
            Result<T> result = await resultUniTask;
            return await result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result> Bind(this UniTask<Result> resultUniTask, Func<UniTask<Result>> func)
        {
            Result result = await resultUniTask;
            return await result.Bind(func);
        }
    }
}
#endif