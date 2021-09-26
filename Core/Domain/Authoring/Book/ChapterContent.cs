using Core.Common.Domain;

namespace Core.Domain.Authoring.Book
{
    public class ChapterContent : SimpleValueObject<string>
    {
        public ChapterContent(string value) : base(value)
        {
        }
    }
}