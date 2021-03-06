using System;
using System.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<T> Finally<T>(this Result result, Func<Result, Task<T>> func)
        {
            return await func(result).DefaultAwait();
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<T, K>(this Result<T> result, Func<Result<T>, Task<K>> func)
        {
            return await func(result).DefaultAwait();
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<T, K, E>(this Result<T, E> result, Func<Result<T, E>, Task<K>> func)
        {
            return await func(result).DefaultAwait();
        }
    }
}
