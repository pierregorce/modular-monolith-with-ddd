﻿#nullable disable

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a failure result with the given error message.
        /// </summary>
        public static Result Failure(string error)
        {
            return new Result(true, error);
        }

        /// <summary>
        ///     Creates a failure result with the given error message.
        /// </summary>
        public static Result<T> Failure<T>(string error)
        {
            return new Result<T>(true, error, default);
        }
    }
}
