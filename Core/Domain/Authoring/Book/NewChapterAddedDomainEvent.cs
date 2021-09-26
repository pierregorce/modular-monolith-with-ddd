using Core.Common.Domain;

namespace Core.Domain.Authoring.Book
{
    public class NewChapterAddedDomainEvent : IDomainEvent
    {
        public ChapterId ChapterId { get; }

        public NewChapterAddedDomainEvent(ChapterId chapterId)
        {
            ChapterId = chapterId;
        }
    }
}