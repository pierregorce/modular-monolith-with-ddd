using Core.Common.Domain;

namespace Core.Domain.Authoring.Book
{
    public class LastName : SimpleValueObject<string>
    {
        public LastName(string value) : base(value)
        {
        }
    }
}