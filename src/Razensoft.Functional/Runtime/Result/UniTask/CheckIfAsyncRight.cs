#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using System;
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static UniTask<Result<T>> CheckIf<T>(this Result<T> result, bool condition, Func<T, UniTask<Result>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return UniTask.FromResult(result);
        }

        public static UniTask<Result<T>> CheckIf<T, K>(this Result<T> result, bool condition, Func<T, UniTask<Result<K>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return UniTask.FromResult(result);
        }

        public static UniTask<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, bool condition, Func<T, UniTask<Result<K, E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return UniTask.FromResult(result);
        }

        public static UniTask<Result<T>> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, UniTask<Result>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return UniTask.FromResult(result);
        }

        public static UniTask<Result<T>> CheckIf<T, K>(this Result<T> result, Func<T, bool> predicate, Func<T, UniTask<Result<K>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return UniTask.FromResult(result);
        }

        public static UniTask<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, UniTask<Result<K, E>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return UniTask.FromResult(result);
        }
    }
}
#endif
