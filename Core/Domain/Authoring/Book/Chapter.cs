using System;
using Core.Common.Domain;

namespace Core.Domain.Authoring.Book
{
    public class Chapter : Entity<ChapterId>
    {
        public int ChapterIndex { get; }
        public ChapterTitle Title { get; }
        public ChapterContent Content { get; set; }

        private Chapter(ChapterId id, int chapterIndex, ChapterTitle title, ChapterContent content) : base(id)
        {
            ChapterIndex = chapterIndex;
            Title = title;
            Content = content;
        }

        public static Chapter Create(ChapterId id, int chapterIndex, ChapterTitle title, ChapterContent content)
        {
            throw new NotImplementedException();
        }
    }
}