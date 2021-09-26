using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
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

    public partial struct Result<T>
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
        public Result<K> ConvertToNewFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);

            return Result.Failure<K>(Error);
        }

        public Result<K> ConvertFailure<K>()
        {
            if (IsSuccess) throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);
            var computedError = $"[ {typeof(K).Name} | {typeof(T).Name} : {Error} ]";
            return Result.Failure<K>(computedError);
        }
    }
}
