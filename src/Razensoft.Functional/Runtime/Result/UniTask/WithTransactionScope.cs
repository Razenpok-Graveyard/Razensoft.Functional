#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
#if NETSTANDARD2_0 || NET5_0
using System;
using System.Transactions;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class ResultExtensions
    {
        private async static UniTask<T> WithTransactionScope<T>(Func<UniTask<T>> f)
            where T : IResult
        {
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await f();
                if (result.IsSuccess)
                {
                    trans.Complete();
                }
                return result;
            }
        }
    }
}
#endif
#endif
