#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async UniTask<Result> SuccessIf(Func<UniTask<bool>> predicate, string error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async UniTask<Result<T>> SuccessIf<T>(Func<UniTask<bool>> predicate, T value, string error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, value, error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async UniTask<Result<T, E>> SuccessIf<T, E>(Func<UniTask<bool>> predicate, T value, E error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, value, error);
        }
    }
}
#endif
