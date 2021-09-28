using Core.Common.Domain;
using Core.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Core.Domain.Authoring.Book
{
    public class BookTitle : ValueObject
    {
        public string MainTitle { get; }
        public string? SecondaryTitle { get; }

        public BookTitle(string mainTitle, string? secondaryTitle)
        {
            MainTitle = mainTitle;
            SecondaryTitle = secondaryTitle;
        }

        public static Result<BookTitle> Create(string mainTitle, string? secondaryTitle)
        {
            if (mainTitle.IsNullOrWhiteSpace()) return Result.Failure<BookTitle>("ERROR 1");
            if (mainTitle.Length > 100) return Result.Failure<BookTitle>("ERROR 2");
            if (mainTitle.Trim() != mainTitle) return Result.Failure<BookTitle>("ERROR 3");

            if (secondaryTitle == null)
            {
                
            }
            
            return Result.Success(new BookTitle(mainTitle, secondaryTitle));
        }
    }
}