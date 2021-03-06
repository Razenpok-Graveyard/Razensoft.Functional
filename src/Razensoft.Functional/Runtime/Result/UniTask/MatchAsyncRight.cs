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
        public static UniTask<K> Match<T, K, E>(this Result<T, E> result, Func<T, UniTask<K>> onSuccess, Func<E, UniTask<K>> onFailure)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static UniTask<K> Match<K, T>(this Result<T> result, Func<T, UniTask<K>> onSuccess, Func<string, UniTask<K>> onFailure)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static UniTask<T> Match<T>(this Result result, Func<UniTask<T>> onSuccess, Func<string, UniTask<T>> onFailure)
        {
            return result.IsSuccess
                ? onSuccess()
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static UniTask Match<T, E>(this Result<T, E> result, Func<T, UniTask> onSuccess, Func<E, UniTask> onFailure)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static UniTask Match<T>(this Result<T> result, Func<T, UniTask> onSuccess, Func<string, UniTask> onFailure)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static UniTask Match(this Result result, Func<UniTask> onSuccess, Func<string, UniTask> onFailure)
        {
            return result.IsSuccess
                ? onSuccess()
                : onFailure(result.Error);
        }
    }
}
#endif
