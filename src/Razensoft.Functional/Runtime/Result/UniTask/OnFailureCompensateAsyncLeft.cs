#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async UniTask<Result<T>> OnFailureCompensate<T>(this UniTask<Result<T>> resultUniTask, Func<Result<T>> func)
        {
            Result<T> result = await resultUniTask;
            return result.OnFailureCompensate(func);
        }

        public static async UniTask<Result> OnFailureCompensate(this UniTask<Result> resultUniTask, Func<Result> func)
        {
            Result result = await resultUniTask;
            return result.OnFailureCompensate(func);
        }

        public static async UniTask<Result<T>> OnFailureCompensate<T>(this UniTask<Result<T>> resultUniTask, Func<string, Result<T>> func)
        {
            Result<T> result = await resultUniTask;
            return result.OnFailureCompensate(func);
        }

        public static async UniTask<Result<T, E>> OnFailureCompensate<T, E>(this UniTask<Result<T, E>> resultUniTask,
            Func<E, Result<T, E>> func)
        {
            Result<T, E> result = await resultUniTask;
            return result.OnFailureCompensate(func);
        }

        public static async UniTask<Result> OnFailureCompensate(this UniTask<Result> resultUniTask, Func<string, Result> func)
        {
            Result result = await resultUniTask;
            return result.OnFailureCompensate(func);
        }
    }
}
#endif
