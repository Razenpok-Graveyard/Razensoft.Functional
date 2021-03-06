#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
#if NETSTANDARD2_0 || NET5_0
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class ResultExtensions
    {
        public static UniTask<Result<K, E>> BindWithTransactionScope<T, K, E>(this UniTask<Result<T, E>> self, Func<T, Result<K, E>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static UniTask<Result<K>> BindWithTransactionScope<T, K>(this UniTask<Result<T>> self, Func<T, Result<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static UniTask<Result<K>> BindWithTransactionScope<K>(this UniTask<Result> self, Func<Result<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static UniTask<Result> BindWithTransactionScope<T>(this UniTask<Result<T>> self, Func<T, Result> f)
            => WithTransactionScope(() => self.Bind(f));

        public static UniTask<Result> BindWithTransactionScope(this UniTask<Result> self, Func<Result> f)
            => WithTransactionScope(() => self.Bind(f));
    }
}
#endif
#endif
