using Core.Common.Domain;

namespace Core.Domain.Authoring.Book
{
    public class ChapterTitle : SimpleValueObject<string>
    {
        public ChapterTitle(string value) : base(value)
        {
        }
    }
}