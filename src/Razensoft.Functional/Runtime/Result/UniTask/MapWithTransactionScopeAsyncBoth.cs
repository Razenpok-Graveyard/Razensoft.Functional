#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
#if NETSTANDARD2_0 || NET5_0
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class ResultExtensions
    {
        public static UniTask<Result<K>> MapWithTransactionScope<T, K>(this UniTask<Result<T>> self, Func<T, UniTask<K>> f)
            => WithTransactionScope(() => self.Map(f));

        public static UniTask<Result<K>> MapWithTransactionScope<K>(this UniTask<Result> self, Func<UniTask<K>> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif
#endif
