using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Domain;
using Core.Domain.Authoring.Book;
using CSharpFunctionalExtensions;

namespace Core.Exemple
{
    public class Author : Entity<AuthorId>, IAggregateRoot<AuthorId>
    {
        public FirstName FirstName { get; private set; }
        public LastName? LastName { get; private set; }
        public bool IsActive { get; private set; }

        private Author(AuthorId id, FirstName firstName, LastName? lastName, bool isActive) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            IsActive = isActive;
        }

        public static Result<Author> CreateNewAuthor(AuthorId authorId, FirstName firstName, LastName? lastName)
        {
            var author = new Author(
                id: authorId,
                firstName: firstName,
                lastName: lastName, 
                isActive: true);
            
            return Result.Success(author);
        }
        
        public Result ChangeName(FirstName firstName, LastName? lastName)
        {
            if(!IsActive) return Result.Failure("Author is not active.");
            FirstName = firstName;
            LastName = LastName;
            return Result.Success();
        }
    }
}