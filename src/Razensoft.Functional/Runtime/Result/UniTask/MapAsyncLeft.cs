#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result<K, E>> Map<T, K, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, K> func)
        {
            Result<T, E> result = await resultUniTask;
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result<K>> Map<T, K>(this UniTask<Result<T>> resultUniTask, Func<T, K> func)
        {
            Result<T> result = await resultUniTask;
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async UniTask<Result<K>> Map<K>(this UniTask<Result> resultUniTask, Func<K> func)
        {
            Result result = await resultUniTask;
            return result.Map(func);
        }
    }
}
#endif
