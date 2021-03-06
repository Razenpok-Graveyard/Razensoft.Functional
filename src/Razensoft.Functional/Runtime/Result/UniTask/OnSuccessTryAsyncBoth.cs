#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class ResultExtensions
    {
        public static async UniTask<Result> OnSuccessTry(this UniTask<Result> UniTask, Func<UniTask> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await UniTask;
            return await result.OnSuccessTry(func, errorHandler);
        }

        public static async UniTask<Result<T>> OnSuccessTry<T>(this UniTask<Result> UniTask, Func<UniTask<T>> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await UniTask;
            return await result.OnSuccessTry(func, errorHandler);
        }

        public static async UniTask<Result> OnSuccessTry<T>(this UniTask<Result<T>> UniTask, Func<T, UniTask> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await UniTask;
            return await result.OnSuccessTry(func, errorHandler);
        }

        public static async UniTask<Result<K>> OnSuccessTry<T, K>(this UniTask<Result<T>> UniTask, Func<T, UniTask<K>> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await UniTask;
            return await result.OnSuccessTry(func, errorHandler);
        }
    }
}
#endif
