﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Razensoft.Functional
{
    public static class MaybeExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, string errorMessage)
        {
            if (maybe.HasNoValue)
                return Result.Failure<T>(errorMessage);

            return Result.Success(maybe.Value);
        }

        public static Result<T, E> ToResult<T, E>(this Maybe<T> maybe, E error)
        {
            if (maybe.HasNoValue)
                return Result.Failure<T, E>(error);

            return Result.Success<T, E>(maybe.Value);
        }

        public static T Unwrap<T>(this Maybe<T> maybe, T defaultValue = default(T))
        {
            return maybe.Unwrap(x => x, defaultValue);
        }

        public static K Unwrap<T, K>(this Maybe<T> maybe, Func<T, K> selector, K defaultValue = default(K))
        {
            if (maybe.HasValue)
                return selector(maybe.Value);

            return defaultValue;
        }

        public static List<T> ToList<T>(this Maybe<T> maybe)
        {
            return maybe.Unwrap(value => new List<T> {value}, new List<T>());
        }

        public static Maybe<T> Where<T>(this Maybe<T> maybe, Func<T, bool> predicate)
        {
            if (maybe.HasNoValue)
                return Maybe<T>.None;

            if (predicate(maybe.Value))
                return maybe;

            return Maybe<T>.None;
        }

        public static Maybe<K> Select<T, K>(this Maybe<T> maybe, Func<T, K> selector)
        {
            return maybe.Map(selector);
        }

        [Obsolete("Use Bind instead of this method")]
        public static Maybe<K> Select<T, K>(this Maybe<T> maybe, Func<T, Maybe<K>> selector)
        {
            return maybe.Bind(selector);
        }

        public static Maybe<K> SelectMany<T, K>(this Maybe<T> maybe, Func<T, Maybe<K>> selector)
        {
            return maybe.Bind(selector);
        }

        public static Maybe<V> SelectMany<T, U, V>(this Maybe<T> maybe,
            Func<T, Maybe<U>> selector,
            Func<T, U, V> project)
        {
            return maybe.Unwrap(
                x => selector(x).Unwrap(u => project(x, u), Maybe<V>.None),
                Maybe<V>.None);
        }

        public static Maybe<K> Map<T, K>(this Maybe<T> maybe, Func<T, K> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return selector(maybe.Value);
        }

        public static Maybe<K> Bind<T, K>(this Maybe<T> maybe, Func<T, Maybe<K>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return selector(maybe.Value);
        }

        public static void Execute<T>(this Maybe<T> maybe, Action<T> action)
        {
            if (maybe.HasNoValue)
                return;

            action(maybe.Value);
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybe" /> is empty, using the result of the supplied <paramref name="fallbackOperation" />, otherwise it returns <paramref name="maybe" />
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> Or<T>(this Maybe<T> maybe, Func<T> fallbackOperation)
        {
            if (maybe.HasNoValue)
                return Maybe<T>.From(fallbackOperation());

            return maybe;
        }

        /// <summary>
        /// Returns <paramref name="fallback" /> if <paramref name="maybe" /> is empty, otherwise it returns <paramref name="maybe" />
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> Or<T>(this Maybe<T> maybe, Maybe<T> fallback)
        {
            if (maybe.HasNoValue)
                return fallback;

            return maybe;
        }

        /// <summary>
        /// Returns the result of <paramref name="fallbackOperation" /> if <paramref name="maybe" /> is empty, otherwise it returns <paramref name="maybe" />
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> Or<T>(this Maybe<T> maybe, Func<Maybe<T>> fallbackOperation)
        {
            if (maybe.HasNoValue)
                return fallbackOperation();

            return maybe;
        }

        public static TE Match<TE, T>(this Maybe<T> maybe, Func<T, TE> Some, Func<TE> None)
        {
            return maybe.HasValue
                ? Some(maybe.Value)
                : None();
        }

        public static void Match<T>(this Maybe<T> maybe, Action<T> Some, Action None)
        {
            if (maybe.HasValue)
            {
                Some(maybe.Value);
            }
            else
            {
                None();
            }
        }

        public static TE Match<TE, TKey, TValue>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, TE> Some, Func<TE> None) =>
            maybe.HasValue ? Some.Invoke(maybe.Value.Key, maybe.Value.Value) : None.Invoke();

        public static void Match<TKey, TValue>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Action<TKey, TValue> Some, Action None)
        {
            if (maybe.HasValue)
            {
                Some.Invoke(maybe.Value.Key, maybe.Value.Value);
            }
            else
            {
                None.Invoke();
            }
        }


        public static IEnumerable<U> Choose<T, U>(this IEnumerable<Maybe<T>> source, Func<T, U> selector)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    if (item.HasValue)
                    {
                        yield return selector(item.Value);
                    }
                }
            }
        }

        public static Maybe<T> TryFirst<T>(this IEnumerable<T> source)
        {
            if (source.Any())
            {
                return Maybe<T>.From(source.First());
            }

            return Maybe<T>.None;
        }

        public static Maybe<T> TryFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var firstOrEmpty = source.Where(predicate).Take(1).ToList();
            if (firstOrEmpty.Any())
            {
                return Maybe<T>.From(firstOrEmpty[0]);
            }

            return Maybe<T>.None;
        }

        public static Maybe<T> TryLast<T>(this IEnumerable<T> source)
        {
            if (source.Any())
            {
                return Maybe<T>.From(source.Last());
            }

            return Maybe<T>.None;
        }

        public static Maybe<T> TryLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var last = source.LastOrDefault(predicate);
            if (last != null)
            {
                return Maybe<T>.From(last);
            }

            return Maybe<T>.None;
        }

#if NET40
        public static Maybe<V> TryFind<K, V>(this IDictionary<K, V> dict, K key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }

            return Maybe<V>.None;
        }
#else
        public static Maybe<V> TryFind<K, V>(this IReadOnlyDictionary<K, V> dict, K key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            return Maybe<V>.None;
        }
#endif
    }
}