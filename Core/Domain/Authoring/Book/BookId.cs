using System;
using Core.Common.Domain;
using Core.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Core.Domain.Authoring.Book
{
    public class BookId : SimpleValueObject<Guid>
    {
        private BookId(Guid value) : base(value)
        {
        }

        public Result<BookId> Create(Guid guid)
        {
            if (guid.IsNullOrEmpty()) return Result.Failure<BookId>("qzd");
            return Result.Success<BookId>(new BookId(guid));
        }
    }
}