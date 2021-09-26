using System;
using Core.Common.Domain;
using CSharpFunctionalExtensions;

namespace Core.Domain.Authoring.Book
{
    public class Money : SimpleValueObject<decimal>
    {
        private Money(decimal value) : base(value)
        {
        }
        
        public static Result<Money> Create(decimal money)
        {
            throw new NotImplementedException();
        }
    }
}