using System;
using Core.Common.Domain;
using CSharpFunctionalExtensions;

namespace Core.Domain.Authoring.Book
{
    public class AuthorRevisionVersion : SimpleValueObject<int>
    {
        private AuthorRevisionVersion(int value) : base(value)
        {
        }

        public static AuthorRevisionVersion InitialVersion { get; set; } = new AuthorRevisionVersion(1);

        public static Result<AuthorRevisionVersion> CreateNewMinorRevision(AuthorRevisionVersion previousVersion)
        {
            throw new NotImplementedException();
        }
    }
}