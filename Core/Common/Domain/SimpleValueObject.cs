using System;
using System.Collections.Generic;

namespace Core.Common.Domain
{
    [Serializable]
    public abstract class SimpleValueObject<T> : ValueObject
    {
        public T Value { get; }

        protected SimpleValueObject(T value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            if (Value != null) yield return Value;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty;
        }

        public static implicit operator T(SimpleValueObject<T> valueObject) => valueObject.Value;
    }
}
