using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Domain;
using CSharpFunctionalExtensions;

namespace Core.Domain.Authoring.Book
{
    public class Author : AggregateRoot<AuthorId>
    {
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public bool IsDead { get; private set; }
        public bool IsActive { get; private set; }
        public IReadOnlyList<BookId> WritedBooks => _writedBooks.ToList();
        
        private readonly IList<BookId> _writedBooks;

        private Author(AuthorId id, FirstName firstName, LastName lastName, IList<BookId> writedBooks) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            _writedBooks = writedBooks;
        }

        public static Result<Author> CreateAuthor(FirstName firstName, LastName lastName)
        {
            Result<AuthorId> authorId = AuthorId.Create(Guid.NewGuid());
            if (authorId.IsFailure) return authorId.ConvertFailure<Author>();
            
            Author author = new Author(
                id: authorId.Value,
                firstName: firstName,
                lastName: lastName,
                writedBooks: new List<BookId>());
            
            return Result.Success<Author>(author);
        }
        
        public static Result<Author> HydrateAuthor(AuthorId authorId, FirstName firstName, LastName lastName, IList<BookId> writedBooks)
        {
            throw new NotImplementedException();
        }

        public Result ChangeName(FirstName firstName, LastName lastName)
        {
            FirstName = firstName;
            LastName = LastName;
            return Result.Success();
        }
        
        public Result AddBook(BookId bookId)
        {
            if(_writedBooks.Any(m=> m == bookId)) return Result.Failure("");
            
            return Result.Success();
        }
    }
}