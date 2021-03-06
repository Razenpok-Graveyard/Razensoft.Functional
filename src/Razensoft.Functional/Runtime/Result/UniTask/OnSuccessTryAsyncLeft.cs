#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class ResultExtensions
    {
        public static async UniTask<Result> OnSuccessTry(this UniTask<Result> UniTask, Action action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await UniTask;
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async UniTask<Result<T>> OnSuccessTry<T>(this UniTask<Result> UniTask, Func<T> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await UniTask;
            return result.OnSuccessTry(func, errorHandler);
        }

        public static async UniTask<Result> OnSuccessTry<T>(this UniTask<Result<T>> UniTask, Action<T> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await UniTask;
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async UniTask<Result<K>> OnSuccessTry<T, K>(this UniTask<Result<T>> UniTask, Func<T, K> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await UniTask;
            return result.OnSuccessTry(action, errorHandler);
        }
    }
}
#endif
