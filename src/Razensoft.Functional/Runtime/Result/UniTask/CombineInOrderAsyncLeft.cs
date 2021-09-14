#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async UniTask<Result> CombineInOrder(this IEnumerable<UniTask<Result>> tasks, string errorMessageSeparator = null)
        {
            Result[] results = await CompleteInOrder(tasks);
            return results.Combine(errorMessageSeparator);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<UniTask<Result<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
        {
            Result<T, E>[] results = await CompleteInOrder(tasks);
            return results.Combine(composerError);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<UniTask<Result<T, E>>> tasks)
            where E : ICombine
        {
            Result<T, E>[] results = await CompleteInOrder(tasks);
            return results.Combine();
        }

        public static async UniTask<Result<IEnumerable<T>>> CombineInOrder<T>(this IEnumerable<UniTask<Result<T>>> tasks, string errorMessageSeparator = null)
        {
            Result<T>[] results = await CompleteInOrder(tasks);
            return results.Combine(errorMessageSeparator);
        }

        public static async UniTask<Result> CombineInOrder(this UniTask<IEnumerable<UniTask<Result>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<UniTask<Result>> tasks = await task;
            return await tasks.CombineInOrder(errorMessageSeparator);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this UniTask<IEnumerable<UniTask<Result<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<UniTask<Result<T, E>>> tasks = await task;
            return await tasks.CombineInOrder(composerError);
        }

        public static async UniTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this UniTask<IEnumerable<UniTask<Result<T, E>>>> task)
            where E : ICombine
        {
            IEnumerable<UniTask<Result<T, E>>> tasks = await task;
            return await tasks.CombineInOrder();
        }

        public static async UniTask<Result<IEnumerable<T>>> CombineInOrder<T>(this UniTask<IEnumerable<UniTask<Result<T>>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<UniTask<Result<T>>> tasks = await task;
            return await tasks.CombineInOrder(errorMessageSeparator);
        }

        public static async UniTask<Result<K, E>> CombineInOrder<T, K, E>(this IEnumerable<UniTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Result<T, E>> results = await CompleteInOrder(tasks);
            return results.Combine(composer, composerError);
        }

        public static async UniTask<Result<K, E>> CombineInOrder<T, K, E>(this IEnumerable<UniTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Result<T, E>> results = await CompleteInOrder(tasks);
            return results.Combine(composer);
        }

        public static async UniTask<Result<K>> CombineInOrder<T, K>(this IEnumerable<UniTask<Result<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await CompleteInOrder(tasks);
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async UniTask<Result<K, E>> CombineInOrder<T, K, E>(this UniTask<IEnumerable<UniTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<UniTask<Result<T, E>>> tasks = await task;
            return await tasks.CombineInOrder(composer, composerError);
        }

        public static async UniTask<Result<K, E>> CombineInOrder<T, K, E>(this UniTask<IEnumerable<UniTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<UniTask<Result<T, E>>> tasks = await task;
            return await tasks.CombineInOrder(composer);
        }

        public static async UniTask<Result<K>> CombineInOrder<T, K>(this UniTask<IEnumerable<UniTask<Result<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<UniTask<Result<T>>> tasks = await task;
            return await tasks.CombineInOrder(composer, errorMessageSeparator);
        }

        public static async UniTask<T[]> CompleteInOrder<T>(IEnumerable<UniTask<T>> tasks)
        {
            List<T> results = new List<T>();
            foreach (var task in tasks)
            {
                results.Add(await task);
            }
            return results.ToArray();
        }
    }
}
#endif
