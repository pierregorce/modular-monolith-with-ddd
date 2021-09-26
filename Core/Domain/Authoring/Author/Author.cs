using System;
using Core.Common.Domain;

namespace Core.Domain.Authoring.Book
{
    public class Author : AggregateRoot<AuthorId>
    {
        public FirstName FirstName { get; }
        public LastName LastName { get; }

        private Author(AuthorId id, FirstName firstName, LastName lastName) : base(id)
        {
            Type = type;
            FirstName = firstName;
            LastName = lastName;
        }

        public static Author CreateNewAuthor()
        {
            throw new NotImplementedException();
        }
    }
}