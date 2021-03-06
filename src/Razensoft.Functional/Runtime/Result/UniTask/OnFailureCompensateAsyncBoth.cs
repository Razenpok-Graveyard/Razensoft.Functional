#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        public static async UniTask<Result<T, E>> OnFailureCompensate<T, E>(this UniTask<Result<T, E>> resultUniTask,
            Func<UniTask<Result<T, E>>> func)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsFailure)
                return await func();

            return result;
        }

        public static async UniTask<Result<T>> OnFailureCompensate<T>(this UniTask<Result<T>> resultUniTask, Func<UniTask<Result<T>>> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsFailure)
                return await func();

            return result;
        }

        public static async UniTask<Result> OnFailureCompensate(this UniTask<Result> resultUniTask, Func<UniTask<Result>> func)
        {
            Result result = await resultUniTask;

            if (result.IsFailure)
                return await func();

            return result;
        }

        public static async UniTask<Result<T>> OnFailureCompensate<T>(this UniTask<Result<T>> resultUniTask, Func<string, UniTask<Result<T>>> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsFailure)
                return await func(result.Error);

            return result;
        }

        public static async UniTask<Result<T, E>> OnFailureCompensate<T, E>(this UniTask<Result<T, E>> resultUniTask,
            Func<E, UniTask<Result<T, E>>> func)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsFailure)
                return await func(result.Error);

            return result;
        }
    }
}
#endif
