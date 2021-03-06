#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async UniTask<K> Match<T, K, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, UniTask<K>> onSuccess, Func<E, UniTask<K>> onFailure)
        {
            return await (await resultUniTask)
                .Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async UniTask<K> Match<K, T>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask<K>> onSuccess, Func<string, UniTask<K>> onFailure)
        {
            return await (await resultUniTask)
                .Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async UniTask<T> Match<T>(this UniTask<Result> resultUniTask, Func<UniTask<T>> onSuccess, Func<string, UniTask<T>> onFailure)
        {
            return await (await resultUniTask)
                .Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async UniTask Match<T, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, UniTask> onSuccess, Func<E, UniTask> onFailure)
        {
            await (await resultUniTask)
                .Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async UniTask Match<T>(this UniTask<Result<T>> resultUniTask, Func<T, UniTask> onSuccess, Func<string, UniTask> onFailure)
        {
            await (await resultUniTask)
                .Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async UniTask Match(this UniTask<Result> resultUniTask, Func<UniTask> onSuccess, Func<string, UniTask> onFailure)
        {
            await (await resultUniTask)
                .Match(onSuccess, onFailure);
        }
    }
}
#endif
