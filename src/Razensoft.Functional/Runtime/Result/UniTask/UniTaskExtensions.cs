#if RAZENSOFT_FUNCTIONAL_UNITASK_SUPPORT
using Cysharp.Threading.Tasks;

namespace Razensoft.Functional
{
    internal static class UniTaskExtensions
    {
        public static UniTask<T> AsCompletedUniTask<T>(this T obj) => UniTask.FromResult(obj);
    }
}
#endif