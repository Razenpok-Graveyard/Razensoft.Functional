#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async UniTask<Result> Combine(this IEnumerable<UniTask<Result>> UniTasks, string errorMessageSeparator = null)
        {
            Result[] results = await UniTask.WhenAll(UniTasks);
            return results.Combine(errorMessageSeparator);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<UniTask<Result<T, E>>> UniTasks, Func<IEnumerable<E>, E> composerError)
        {
            Result<T, E>[] results = await UniTask.WhenAll(UniTasks);
            return results.Combine(composerError);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<UniTask<Result<T, E>>> UniTasks)
            where E : ICombine
        {
            Result<T, E>[] results = await UniTask.WhenAll(UniTasks);
            return results.Combine();
        }

        public static async UniTask<Result<IEnumerable<T>>> Combine<T>(this IEnumerable<UniTask<Result<T>>> UniTasks, string errorMessageSeparator = null)
        {
            Result<T>[] results = await UniTask.WhenAll(UniTasks);
            return results.Combine(errorMessageSeparator);
        }

        public static async UniTask<Result> Combine(this UniTask<IEnumerable<Result>> UniTask, string errorMessageSeparator = null)
        {
            IEnumerable<Result> results = await UniTask;
            return results.Combine(errorMessageSeparator);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> Combine<T, E>(this UniTask<IEnumerable<Result<T, E>>> UniTask, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Result<T, E>> results = await UniTask;
            return results.Combine(composerError);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> Combine<T, E>(this UniTask<IEnumerable<Result<T, E>>> UniTask)
            where E : ICombine
        {
            IEnumerable<Result<T, E>> results = await UniTask;
            return results.Combine();
        }

        public static async UniTask<Result<IEnumerable<T>>> Combine<T>(this UniTask<IEnumerable<Result<T>>> UniTask, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await UniTask;
            return results.Combine(errorMessageSeparator);
        }

        public static async UniTask<Result> Combine(this UniTask<IEnumerable<UniTask<Result>>> UniTask, string errorMessageSeparator = null)
        {
            IEnumerable<UniTask<Result>> UniTasks = await UniTask;
            return await UniTasks.Combine(errorMessageSeparator);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> Combine<T, E>(this UniTask<IEnumerable<UniTask<Result<T, E>>>> UniTask, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<UniTask<Result<T, E>>> UniTasks = await UniTask;
            return await UniTasks.Combine(composerError);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> Combine<T, E>(this UniTask<IEnumerable<UniTask<Result<T, E>>>> UniTask)
            where E : ICombine
        {
            IEnumerable<UniTask<Result<T, E>>> UniTasks = await UniTask;
            return await UniTasks.Combine();
        }

        public static async UniTask<Result<IEnumerable<T>>> Combine<T>(this UniTask<IEnumerable<UniTask<Result<T>>>> UniTask, string errorMessageSeparator = null)
        {
            IEnumerable<UniTask<Result<T>>> UniTasks = await UniTask;
            return await UniTasks.Combine(errorMessageSeparator);
        }

        public static async UniTask<Result<K, E>> Combine<T, K, E>(this IEnumerable<UniTask<Result<T, E>>> UniTasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Result<T, E>> results = await UniTask.WhenAll(UniTasks);
            return results.Combine(composer, composerError);
        }

        public static async UniTask<Result<K, E>> Combine<T, K, E>(this IEnumerable<UniTask<Result<T, E>>> UniTasks, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Result<T, E>> results = await UniTask.WhenAll(UniTasks);
            return results.Combine(composer);
        }

        public static async UniTask<Result<K>> Combine<T, K>(this IEnumerable<UniTask<Result<T>>> UniTasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await UniTask.WhenAll(UniTasks);
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async UniTask<Result<K, E>> Combine<T, K, E>(this UniTask<IEnumerable<UniTask<Result<T, E>>>> UniTask, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<UniTask<Result<T, E>>> UniTasks = await UniTask;
            return await UniTasks.Combine(composer, composerError);
        }

        public static async UniTask<Result<K, E>> Combine<T, K, E>(this UniTask<IEnumerable<UniTask<Result<T, E>>>> UniTask, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<UniTask<Result<T, E>>> UniTasks = await UniTask;
            return await UniTasks.Combine(composer);
        }

        public static async UniTask<Result<K>> Combine<T, K>(this UniTask<IEnumerable<UniTask<Result<T>>>> UniTask, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<UniTask<Result<T>>> UniTasks = await UniTask;
            return await UniTasks.Combine(composer, errorMessageSeparator);
        }
    }
}
#endif
