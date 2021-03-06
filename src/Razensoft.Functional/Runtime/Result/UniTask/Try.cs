#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public partial struct Result
    {
        /// <summary>
        ///     Attempts to execute the supplied action. Returns a Result indicating whether the action executed successfully.
        /// </summary>
        public static async UniTask<Result> Try(Func<UniTask> action, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                await action();
                return Success();
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Failure(message);
            }
        }

        /// <summary>
        ///     Attempts to execute the supplied function. Returns a Result indicating whether the function executed successfully.
        ///     If the function executed successfully, the result contains its return value.
        /// </summary>
        public static async UniTask<Result<T>> Try<T>(Func<UniTask<T>> func, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                var result = await func();
                return Success(result);
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Failure<T>(message);
            }
        }

        /// <summary>
        ///     Attempts to execute the supplied function. Returns a Result indicating whether the function executed successfully.
        ///     If the function executed successfully, the result contains its return value.
        /// </summary>
        public static async UniTask<Result<T, E>> Try<T, E>(Func<UniTask<T>> func, Func<Exception, E> errorHandler)
        {
            try
            {
                var result = await func();
                return Success<T, E>(result);
            }
            catch (Exception exc)
            {
                E error = errorHandler(exc);
                return Failure<T, E>(error);
            }
        }
    }
}
#endif
