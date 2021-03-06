#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async UniTask<Result> FailureIf(Func<UniTask<bool>> failurePredicate, string error)
        {
            bool isFailure = await failurePredicate();
            return SuccessIf(!isFailure, error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async UniTask<Result<T>> FailureIf<T>(Func<UniTask<bool>> failurePredicate, T value, string error)
        {
            bool isFailure = await failurePredicate();
            return SuccessIf(!isFailure, value, error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async UniTask<Result<T, E>> FailureIf<T, E>(Func<UniTask<bool>> failurePredicate, T value, E error)
        {
            bool isFailure = await failurePredicate();
            return SuccessIf(!isFailure, value, error);
        }
    }
}
#endif
