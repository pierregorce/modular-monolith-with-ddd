using System.Collections.Generic;
using System.Linq;

namespace Core.Common.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IList{T}"/>.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
		/// Sorts the elements of a sequence according to a key and the sort order.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="query" />.</typeparam>
		/// <param name="query">A sequence of values to order.</param>
		/// <param name="key">Name of the property of <see cref="TSource"/> by which to sort the elements.</param>
		/// <param name="ascending">True for ascending order, false for descending order.</param>
		/// <returns>An <see cref="T:System.Linq.IOrderedQueryable`1" /> whose elements are sorted according to a key and sort order.</returns>
		public static IList<TSource> OrderBy<TSource>(this IList<TSource> query, string key, bool ascending = true)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return query;
            }

            return ascending
                ? query.OrderBy(s => s.GetType().GetProperty("PropertyName")?.GetValue(s, null)).ToList()
                : query.OrderByDescending(s => s.GetType().GetProperty("PropertyName")?.GetValue(s, null)).ToList();
        }

        /// <summary>
        /// Split list into smallers lists
        /// </summary>
        public static List<List<T>> ChunkBy<T>(this IList<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        /// <summary>
        /// Return true if list is null or empty
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Check if a source list is totally include in another list
        /// Warning, algorithm complexity is O(n²) => CPU intensive
        /// </summary>
        public static bool ExistsIn<T>(this IEnumerable<T> source, IEnumerable<T> anotherList)
        {
            foreach (T sourceItem in source)
            {
                if (!anotherList.Contains(sourceItem)) return false;
            }

            return true;
        }
    }
}
