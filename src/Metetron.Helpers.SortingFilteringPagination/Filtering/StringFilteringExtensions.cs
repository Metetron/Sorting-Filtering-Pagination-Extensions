using System;
using System.Linq;
using System.Linq.Expressions;

namespace Metetron.Helpers.SortingFilteringPagination.Filtering
{
    public static class StringFilteringExtensions
    {
        /// <summary>
        /// Applies a 'contains'- filter to the query
        /// </summary>
        /// <param name="query">The IQueryable to query</param>
        /// <param name="propertyToFilter">The property to query</param>
        /// <param name="filter">The string to search for</param>
        /// <typeparam name="T">The type of object to query</typeparam>
        /// <returns>The filtered IQueryable</returns>
        public static IQueryable<T> ApplyContainsFilter<T>(this IQueryable<T> query, Expression<Func<T, string>> propertyToFilter, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return query;

            return query.Where(q => propertyToFilter.Compile().Invoke(q).IndexOf(filter) >= 0);
        }

        /// <summary>
        /// Applies a 'contains'- filter to the query
        /// </summary>
        /// <param name="query">The IQueryable to query</param>
        /// <param name="propertyToFilter">The property to query</param>
        /// <param name="filter">The string to search for</param>
        /// <param name="comparisonType">The StringComparison type to use</param>
        /// <typeparam name="T">The type of object to query</typeparam>
        /// <returns>The filtered IQueryable</returns>
        public static IQueryable<T> ApplyContainsFilter<T>(this IQueryable<T> query, Expression<Func<T, string>> propertyToFilter, string filter, StringComparison comparisonType)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return query;

            return query.Where(q => propertyToFilter.Compile().Invoke(q).IndexOf(filter, comparisonType) >= 0);
        }

        /// <summary>
        /// Applies an 'equal'- filter to the query
        /// </summary>
        /// <param name="query">The IQueryable to query</param>
        /// <param name="propertyToFilter">The property to query</param>
        /// <param name="filter">The string to search for</param>
        /// <typeparam name="T">The type of object to query</typeparam>
        /// <returns>The filtered IQueryable</returns>
        public static IQueryable<T> ApplyEqualsFilter<T>(this IQueryable<T> query, Expression<Func<T, string>> propertyToFilter, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return query;

            return query.Where(q => propertyToFilter.Compile().Invoke(q).Equals(filter));
        }

        /// <summary>
        /// Applies an 'equal'- filter to the query
        /// </summary>
        /// <param name="query">The IQueryable to query</param>
        /// <param name="propertyToFilter">The property to query</param>
        /// <param name="filter">The string to search for</param>
        /// <param name="comparisonType">The StringComparison type to use</param>
        /// <typeparam name="T">The type of object to query</typeparam>
        /// <returns>The filtered IQueryable</returns>
        public static IQueryable<T> ApplyEqualsFilter<T>(this IQueryable<T> query, Expression<Func<T, string>> propertyToFilter, string filter, StringComparison comparisonType)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return query;

            return query.Where(q => propertyToFilter.Compile().Invoke(q).Equals(filter, comparisonType));
        }
    }
}