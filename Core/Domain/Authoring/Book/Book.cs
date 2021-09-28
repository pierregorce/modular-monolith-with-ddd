using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Domain;
using CSharpFunctionalExtensions;

namespace Core.Domain.Authoring.Book
{
    public class BookAggregate : AggregateRoot<BookId>
    {
        public BookId BookId { get; }
        public BookTitle? Title { get; private set; }
        public AuthorId AuthorId { get; private set; }
        public ProgressionStatusEnum ProgressionStatus { get; private set; }
        public AuthorRevisionVersion? RevisionVersion { get; private set; }

        public IReadOnlyList<Chapter> Chapters => _chapters.ToList();
        private readonly IList<Chapter> _chapters;

        private BookAggregate(BookId id, BookId bookId, BookTitle? title, AuthorId authorId, ProgressionStatusEnum progressionStatus, AuthorRevisionVersion? revisionVersion, IList<Chapter> chapters) : base(id)
        {
            BookId = bookId;
            Title = title;
            AuthorId = authorId;
            ProgressionStatus = progressionStatus;
            RevisionVersion = revisionVersion;
            _chapters = chapters;
        }
        
        public static BookAggregate CreateDraftBook(BookId id, BookId bookId, BookTitle? title, AuthorId authorId)
        {
            return new BookAggregate(
                id: id,
                bookId: bookId,
                title: title,
                authorId: authorId,
                progressionStatus: ProgressionStatusEnum.DRAFT,
                authorEstimatedPrice: null,
                chapters: new List<Chapter>()
            );
        }

        public Result SetEstimatedPrice(Money authorEstimatedPrice)
        {
            if (ProgressionStatus == ProgressionStatusEnum.ACTIVE)
            {
                AuthorEstimatedPrice = authorEstimatedPrice;
                return Result.Success();
            }
            else
            {
                return Result.Success($"An {nameof(AuthorEstimatedPrice)} can't be set while book is not editable.");
            }
        }

        public Result DefineTargetPrice(Money targetPrice)
        {
            if (ProgressionStatus == ProgressionStatusEnum.FINISHED)
            {
                TargetPrice = TargetPrice;
                return Result.Success();
            }
            else
            {
                return Result.Success($"An {nameof(TargetPrice)} can't be set while book is not finished authoring.");
            }
        }

        public Result FinishBookAuthoring()
        {
            if (AuthorEstimatedPrice == null) return Result.Failure($"An {nameof(AuthorEstimatedPrice)} must be set for close the authoring process.");
            if (_chapters.Count < 1) return Result.Failure($"There must be at least one chapter to finish authoring.");

            ProgressionStatus = ProgressionStatusEnum.FINISHED;
            RevisionVersion = AuthorRevisionVersion.InitialVersion;
            
            return Result.Success();
        }
        
        public Result EditChapterContent(ChapterId chapterId, ChapterContent newContent)
        {
            if (ProgressionStatus != ProgressionStatusEnum.DRAFT || ProgressionStatus != ProgressionStatusEnum.ACTIVE)
                return Result.Failure($"Chapter can't be edited when book authoring is not draft or active.");

            Chapter? chapter = _chapters.SingleOrDefault(m => m.Id == chapterId);
            if (chapter == null) return Result.Failure("Chapter is not found.");

            chapter.Content = newContent;

            return Result.Success();
        }
        
        public Result CreateRevision(ChapterId chapterId, ChapterContent newContent)
        {
            if (ProgressionStatus != ProgressionStatusEnum.FINISHED)
                return Result.Failure($"A revision can only be created when book is finished");
            
            if(RevisionVersion == null)
                return Result.Failure($"The initial version must already have been set.");

            Chapter? chapter = _chapters.SingleOrDefault(m => m.Id == chapterId);
            if (chapter == null) return Result.Failure("Chapter is not found.");

            chapter.Content = newContent;
            
            Result<AuthorRevisionVersion> newRevisionVersionResult = AuthorRevisionVersion.CreateNewMinorRevision(RevisionVersion);
            if (newRevisionVersionResult.IsFailure) return newRevisionVersionResult.ConvertFailure<AuthorRevisionVersion>();
            RevisionVersion = newRevisionVersionResult.Value;

            return Result.Success();
        }

        public Result<ChapterId> AddNewChapter(ChapterTitle title, ChapterContent content)
        {
            int newChapterIndex = _chapters.Count + 1;

            Result<ChapterId> newChapterId = ChapterId.Create(Guid.NewGuid());
            if (newChapterId.IsFailure) return newChapterId.ConvertFailure<ChapterId>();

            Chapter newChapter = Chapter.Create(newChapterId.Value, newChapterIndex, title, content);
            _chapters.Add(newChapter);

            AddDomainEvent(new NewChapterAddedDomainEvent(newChapterId.Value));

            return Result.Success(newChapter.Id);
        }
    }
}