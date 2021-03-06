#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static UniTask<Result<T>> CheckIf<T>(this UniTask<Result<T>> resultUniTask, bool condition, Func<T, Result> func)
        {
            if (condition)
                return resultUniTask.Check(func);
            else
                return resultUniTask;
        }

        public static UniTask<Result<T>> CheckIf<T, K>(this UniTask<Result<T>> resultUniTask, bool condition, Func<T, Result<K>> func)
        {
            if (condition)
                return resultUniTask.Check(func);
            else
                return resultUniTask;
        }

        public static UniTask<Result<T, E>> CheckIf<T, K, E>(this UniTask<Result<T, E>> resultUniTask, bool condition, Func<T, Result<K, E>> func)
        {
            if (condition)
                return resultUniTask.Check(func);
            else
                return resultUniTask;
        }


        public static async UniTask<Result<T>> CheckIf<T>(this UniTask<Result<T>> resultUniTask, Func<T, bool> predicate, Func<T, Result> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async UniTask<Result<T>> CheckIf<T, K>(this UniTask<Result<T>> resultUniTask, Func<T, bool> predicate, Func<T, Result<K>> func)
        {
            Result<T> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async UniTask<Result<T, E>> CheckIf<T, K, E>(this UniTask<Result<T, E>> resultUniTask, Func<T, bool> predicate, Func<T, Result<K, E>> func)
        {
            Result<T, E> result = await resultUniTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }
    }
}
#endif
