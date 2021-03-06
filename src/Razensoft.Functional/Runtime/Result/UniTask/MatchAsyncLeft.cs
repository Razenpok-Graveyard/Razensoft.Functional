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
        public static async UniTask<K> Match<T, K, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, K> onSuccess, Func<E, K> onFailure)
        {
            return (await resultUniTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async UniTask<K> Match<K, T>(this UniTask<Result<T>> resultUniTask, Func<T, K> onSuccess, Func<string, K> onFailure)
        {
            return (await resultUniTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async UniTask<T> Match<T>(this UniTask<Result> resultUniTask, Func<T> onSuccess, Func<string, T> onFailure)
        {
            return (await resultUniTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async UniTask Match<T, E>(this UniTask<Result<T, E>> resultUniTask, Action<T> onSuccess, Action<E> onFailure)
        {
            (await resultUniTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async UniTask Match<T>(this UniTask<Result<T>> resultUniTask, Action<T> onSuccess, Action<string> onFailure)
        {
            (await resultUniTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async UniTask Match(this UniTask<Result> resultUniTask, Action onSuccess, Action<string> onFailure)
        {
            (await resultUniTask).Match(onSuccess, onFailure);
        }
    }
}
#endif
