#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
#if NETSTANDARD2_0 || NET5_0
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class ResultExtensions
    {
        public static UniTask<Result<K, E>> BindWithTransactionScope<T, K, E>(this Result<T, E> self, Func<T, UniTask<Result<K, E>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static UniTask<Result<K>> BindWithTransactionScope<T, K>(this Result<T> self, Func<T, UniTask<Result<K>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static UniTask<Result<K>> BindWithTransactionScope<K>(this Result self, Func<UniTask<Result<K>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static UniTask<Result> BindWithTransactionScope<T>(this Result<T> self, Func<T, UniTask<Result>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static UniTask<Result> BindWithTransactionScope(this Result self, Func<UniTask<Result>> f)
            => WithTransactionScope(() => self.Bind(f));
    }
}
#endif
#endif
