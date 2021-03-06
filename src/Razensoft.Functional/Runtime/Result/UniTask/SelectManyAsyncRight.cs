#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static UniTask<Result<TR>> SelectMany<T, TK, TR>(
            this Result<T> result,
            Func<T, UniTask<Result<TK>>> func,
            Func<T, TK, TR> project)
        {
            return result
                .Bind(func)
                .Map(x => project(result.Value, x));
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static UniTask<Result<TR, TE>> SelectMany<T, TK, TE, TR>(
            this Result<T, TE> result,
            Func<T, UniTask<Result<TK, TE>>> func,
            Func<T, TK, TR> project)
        {
            return result
                .Bind(func)
                .Map(x => project(result.Value, x));
        }
    }
}
#endif