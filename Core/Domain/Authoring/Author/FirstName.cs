using Core.Common.Domain;

namespace Core.Domain.Authoring.Book
{
    public class FirstName  : SimpleValueObject<string>
    {
        public FirstName(string value) : base(value)
        {
        }
    }
}