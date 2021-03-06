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
    }
}
#endif