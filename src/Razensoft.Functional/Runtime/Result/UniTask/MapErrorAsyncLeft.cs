#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async UniTask<Result> MapError(this UniTask<Result> resultUniTask, Func<string, string> errorFactory)
        {
            var result = await resultUniTask;

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async UniTask<Result<T>> MapError<T>(this UniTask<Result<T>> resultUniTask, Func<string, string> errorFactory)
        {
            var result = await resultUniTask;

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async UniTask<Result<T, E>> MapError<T, E>(this UniTask<Result<T>> resultUniTask, Func<string, E> errorFactory)
        {
            var result = await resultUniTask;

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async UniTask<Result<T>> MapError<T, E>(this UniTask<Result<T, E>> resultTask, Func<E, string> errorFactory)
        {
            var result = await resultTask;

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async UniTask<Result<T, E2>> MapError<T, E, E2>(this UniTask<Result<T, E>> resultUniTask, Func<E, E2> errorFactory)
        {
            var result = await resultUniTask;

            return result.MapError(errorFactory);
        }
    }
}
#endif