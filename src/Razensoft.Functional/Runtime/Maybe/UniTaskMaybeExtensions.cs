#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static class UniTaskMaybeExtensions
    {
        public static async UniTask<Result<T>> ToResult<T>(this UniTask<Maybe<T>> maybeUniTask, string errorMessage)
        {
            Maybe<T> maybe = await maybeUniTask;
            return maybe.ToResult(errorMessage);
        }

        public static async UniTask<Result<T, E>> ToResult<T, E>(this UniTask<Maybe<T>> maybeUniTask, E error)
        {
            Maybe<T> maybe = await maybeUniTask;
            return maybe.ToResult(error);
        }

        public static async UniTask<Maybe<T>> Where<T>(this UniTask<Maybe<T>> maybeUniTask, Func<T, bool> predicate)
        {
            Maybe<T> maybe = await maybeUniTask;
            return maybe.Where(predicate);
        }

        public static async UniTask<Maybe<T>> Where<T>(this Maybe<T> maybe, Func<T, UniTask<bool>> predicate)
        {
            if (maybe.HasNoValue)
                return Maybe<T>.None;

            if (await predicate(maybe.Value))
                return maybe;

            return Maybe<T>.None;
        }

        public static async UniTask<Maybe<T>> Where<T>(this UniTask<Maybe<T>> maybeUniTask, Func<T, UniTask<bool>> predicate)
        {
            Maybe<T> maybe = await maybeUniTask;
            return await maybe.Where(predicate);
        }

        public static async UniTask<Maybe<K>> Map<T, K>(this UniTask<Maybe<T>> maybeUniTask, Func<T, K> selector)
        {
            Maybe<T> maybe = await maybeUniTask;
            return maybe.Map(selector);
        }

        public static async UniTask<Maybe<K>> Map<T, K>(this Maybe<T> maybe, Func<T, UniTask<K>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return await selector(maybe.Value);
        }

        public static async UniTask<Maybe<K>> Map<T, K>(this UniTask<Maybe<T>> maybeUniTask, Func<T, UniTask<K>> selector)
        {
            Maybe<T> maybe = await maybeUniTask;
            return await maybe.Map(selector);
        }

        public static async UniTask<Maybe<K>> Bind<T, K>(this UniTask<Maybe<T>> maybeUniTask, Func<T, Maybe<K>> selector)
        {
            Maybe<T> maybe = await maybeUniTask;
            return maybe.Bind(selector);
        }

        public static UniTask<Maybe<K>> Bind<T, K>(this Maybe<T> maybe, Func<T, UniTask<Maybe<K>>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None.AsCompletedUniTask();

            return selector(maybe.Value);
        }

        public static async UniTask<Maybe<K>> Bind<T, K>(this UniTask<Maybe<T>> maybeUniTask, Func<T, UniTask<Maybe<K>>> selector)
        {
            Maybe<T> maybe = await maybeUniTask;
            return await maybe.Bind(selector);
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the supplied <paramref name="fallback" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async UniTask<Maybe<T>> Or<T>(this UniTask<Maybe<T>> maybeTask, T fallback)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
                return Maybe<T>.From(fallback);

            return maybe;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the supplied <paramref name="fallback" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async UniTask<Maybe<T>> Or<T>(this UniTask<Maybe<T>> maybeTask, UniTask<T> fallback)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
            {
                var value = await fallback;
                return Maybe<T>.From(value);
            }

            return maybe;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the result of the supplied <paramref name="fallbackOperation" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async UniTask<Maybe<T>> Or<T>(this UniTask<Maybe<T>> maybeTask, Func<T> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
                return Maybe<T>.From(fallbackOperation());

            return maybe;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the result of the supplied <paramref name="fallbackOperation" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async UniTask<Maybe<T>> Or<T>(this UniTask<Maybe<T>> maybeTask, Func<UniTask<T>> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
            {
                var value = await fallbackOperation();

                return Maybe<T>.From(value);
            }

            return maybe;
        }

        /// <summary>
        /// Returns <paramref name="fallback" /> if <paramref name="maybeTask" /> is empty, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async UniTask<Maybe<T>> Or<T>(this UniTask<Maybe<T>> maybeTask, Maybe<T> fallback)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
                return fallback;

            return maybe;
        }

        /// <summary>
        /// Returns <paramref name="fallbackOperation" /> if <paramref name="maybeTask" /> is empty, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async UniTask<Maybe<T>> Or<T>(this UniTask<Maybe<T>> maybeTask, Func<Maybe<T>> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
                return fallbackOperation();

            return maybe;
        }

        /// <summary>
        /// Returns <paramref name="fallbackOperation" /> if <paramref name="maybeTask" /> is empty, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async UniTask<Maybe<T>> Or<T>(this UniTask<Maybe<T>> maybeTask, Func<UniTask<Maybe<T>>> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
                return await fallbackOperation();

            return maybe;
        }
    }
}
#endif