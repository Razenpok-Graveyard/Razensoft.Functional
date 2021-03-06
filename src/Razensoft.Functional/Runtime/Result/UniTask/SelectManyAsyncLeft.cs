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
        public static async UniTask<Result<TR>> SelectMany<T, TK, TR>(
            this UniTask<Result<T>> resultUniTask,
            Func<T, Result<TK>> func,
            Func<T, TK, TR> project)
        {
            Result<T> result = await resultUniTask;
            return result.SelectMany(func, project);
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async UniTask<Result<TR, TE>> SelectMany<T, TK, TE, TR>(
            this UniTask<Result<T, TE>> resultUniTask,
            Func<T, Result<TK, TE>> func,
            Func<T, TK, TR> project)
        {
            Result<T, TE> result = await resultUniTask;
            return result.SelectMany(func, project);
        }
    }
}
#endif