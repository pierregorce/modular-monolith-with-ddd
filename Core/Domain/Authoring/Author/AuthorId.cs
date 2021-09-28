using System;
using Core.Common.Domain;
using CSharpFunctionalExtensions;

namespace Core.Domain.Authoring.Book
{
    public class AuthorId  : SimpleValueObject<Guid>
    {
        private AuthorId(Guid value) : base(value)
        {
        }

        public static Result<AuthorId> Create(Guid value)
        {
            throw new NotImplementedException();
        }
    }
}