using System.Linq;
using Core.Common.Domain;
using Core.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Core.Purity
{
    public class BookTitle : SimpleValueObject<string>
    {
        private BookTitle(string value) : base(value)
        {
        }

        public Result<BookTitle> Create(string title)
        {
            if (title.IsNullOrWhiteSpace()) return Result.Failure<BookTitle>("ERROR 1");
            if (title.Length > 100) return Result.Failure<BookTitle>("ERROR 2");
            if (title.Trim() != title) return Result.Failure<BookTitle>("ERROR 3");
            return Result.Success(new BookTitle(title));
        }
    }
}

namespace Core.PerformanceLoose
{
    public class BookTitle : SimpleValueObject<string>
    {
        private BookTitle(string value) : base(value)
        {
        }

        public static Result<BookTitle> Create(string title, string[] allBookTitles)
        {
            if (title.IsNullOrWhiteSpace()) return Result.Failure<BookTitle>("ERROR 1");
            if (title.Length > 100) return Result.Failure<BookTitle>("ERROR 2");
            if (title.Trim() != title) return Result.Failure<BookTitle>("ERROR 3");
            if (allBookTitles.Contains(title)) return Result.Failure<BookTitle>("ERROR 4");

            return Result.Success(new BookTitle(title));
        }
    }
}

namespace Core.PurityLoose
{
    public class BookTitle : SimpleValueObject<string>
    {
        private BookTitle(string value) : base(value)
        {
        }

        public static Result<BookTitle> Create(string title, IsBookMustBeUniqueBuisnessRule bookMustBeUniqueBuisnessRule)
        {
            if (title.IsNullOrWhiteSpace()) return Result.Failure<BookTitle>("ERROR 1");
            if (title.Length > 100) return Result.Failure<BookTitle>("ERROR 2");
            if (title.Trim() != title) return Result.Failure<BookTitle>("ERROR 3");
            if(!bookMustBeUniqueBuisnessRule.IsValid()) return Result.Failure<BookTitle>("ERROR 4");
            return Result.Success(new BookTitle(title));
        }
    }
    
    
    
    
    
    
    
    
    
    
    public interface IsBookMustBeUniqueBuisnessRule
    {
        bool IsValid();
    }
}
