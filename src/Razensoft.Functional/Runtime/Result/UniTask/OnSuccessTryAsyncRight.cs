#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class ResultExtensions
    {
        public static async UniTask<Result> OnSuccessTry(this Result result, Func<UniTask> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
               ? result
               : await Result.Try(func, errorHandler);
        }

        public static async UniTask OnSuccessTry<T>(this Result<T> result, Func<T, UniTask> func)
        {
            if (result.IsSuccess)
            {
                await func(result.Value);
            }
        }

        public static async UniTask OnSuccessTry<T, E>(this Result<T, E> result, Func<T, UniTask> func)
        {
            if (result.IsSuccess)
            {
                await func(result.Value);
            }
        }

        public static async UniTask<Result<T>> OnSuccessTry<T>(this Result result, Func<UniTask<T>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
               ? Result.Failure<T>(result.Error)
               : await Result.Try(func, errorHandler);
        }

        public static async UniTask<Result> OnSuccessTry<T>(this Result<T> result, Func<T, UniTask> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
               ? Result.Failure(result.Error)
               : await Result.Try(() => func(result.Value), errorHandler);
        }

        public static async UniTask<Result<K>> OnSuccessTry<T, K>(this Result<T> result, Func<T, UniTask<K>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
               ? Result.Failure<K>(result.Error)
               : await Result.Try(() => func(result.Value), errorHandler);
        }
    }
}
#endif
