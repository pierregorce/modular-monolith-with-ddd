using System;
using Core.Common.Domain;

namespace Core.Domain.Authoring.Book
{
    public class AuthorId  : SimpleValueObject<Guid>
    {
        public AuthorId(Guid value) : base(value)
        {
        }
    }
}