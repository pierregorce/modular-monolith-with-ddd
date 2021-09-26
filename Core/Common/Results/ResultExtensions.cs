using System;
using CSharpFunctionalExtensions;

namespace Bazimo.Core.SharedKernel.Common.Results
{
    public static class ResultExtensions
    {
        public static T ValueOrException<T>(this Result<T> result)
        {
            if(result.IsFailure) throw new Exception(result.Error);
            return result.Value;
        }
    }
}