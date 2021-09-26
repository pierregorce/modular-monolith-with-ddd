using System;
using Core.Common.Domain;
using CSharpFunctionalExtensions;

namespace Core.Domain.Authoring.Book
{
    public class ChapterId : SimpleValueObject<Guid>
    {
        private ChapterId(Guid value) : base(value)
        {
        }

        public static Result<ChapterId> Create(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}