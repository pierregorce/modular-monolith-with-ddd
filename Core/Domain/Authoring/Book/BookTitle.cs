using Core.Common.Domain;
using Core.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Core.Domain.Authoring.Book
{
    public class BookTitle : SimpleValueObject<string>
    {
        public BookTitle(string value) : base(value)
        {
        }

        public Result<BookTitle> Create(string title)
        {
            if (title.IsNullOrWhiteSpace()) return Result.Failure<BookTitle>("ERROR 1");
            if (title.Length > 100) return Result.Failure<BookTitle>("ERROR 2");
            if (title.Trim() != title) return Result.Failure<BookTitle>("ERROR 3");
            
            return Result.Success<BookTitle>(new BookTitle(title));
        }
    }
}