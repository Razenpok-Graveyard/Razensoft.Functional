#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static async UniTask<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<UniTask<Result<T>>> func)
        {
            if (result.IsFailure)
                return await func();

            return result;
        }

        public static async UniTask<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result, Func<UniTask<Result<T, E>>> func)
        {
            if (result.IsFailure)
                return await func();

            return result;
        }

        public static async UniTask<Result> OnFailureCompensate(this Result result, Func<UniTask<Result>> func)
        {
            if (result.IsFailure)
                return await func();

            return result;
        }

        public static async UniTask<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<string, UniTask<Result<T>>> func)
        {
            if (result.IsFailure)
                return await func(result.Error);

            return result;
        }

        public static async UniTask<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result,
            Func<E, UniTask<Result<T, E>>> func)
        {
            if (result.IsFailure)
                return await func(result.Error);

            return result;
        }
    }
}
#endif
