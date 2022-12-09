using System;

namespace Razensoft.Functional
{
    public partial class Result
    {
        /// <summary>
        ///     Throws if the result is a success. Else returns a new failure result of the given type.
        /// </summary>
        public Result<K> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Messages.ConvertFailureExceptionOnSuccess);

            return Failure<K>(Error);
        }
    }

    public partial class Result<T>
    {
        /// <summary>
        ///     Throws if the result is a success. Else returns a new failure result.
        /// </summary>
        public Result ConvertFailure()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);

            return Result.Failure(Error);
        }

        /// <summary>
        ///     Throws if the result is a success. Else returns a new failure result of the given type.
        /// </summary>
        public Result<K> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);

            return Result.Failure<K>(Error);
        }
    }

    public partial class Result<T, E>
    {
        /// <summary>
        ///     Throws if the result is a success. Else returns a new failure result of the given type.
        /// </summary>
        public Result<K, E> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);

            return Result.Failure<K, E>(Error);
        }
    }
}
