using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Common.Extensions
{
    public static class CollectionExtension
    {
        public static void RemoveAll<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                T element = collection.ElementAt(i);
                if (predicate(element))
                {
                    collection.Remove(element);
                    i--;
                }
            }
        }
    }
}
