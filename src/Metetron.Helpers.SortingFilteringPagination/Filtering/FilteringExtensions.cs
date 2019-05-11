using System;
using System.Linq;
using System.Linq.Expressions;

namespace Metetron.Helpers.SortingFilteringPagination.Filtering
{
    public static class FilteringExtensions
    {
        public static IQueryable<T> ApplyContainsFilter<T>(this IQueryable<T> query, Expression<Func<T, string>> propertyToFilter, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return query;

            return query.Where(q => propertyToFilter.Compile().Invoke(q).IndexOf(filter) >= 0);
        }

        public static IQueryable<T> ApplyContainsFilter<T>(this IQueryable<T> query, Expression<Func<T, string>> propertyToFilter, string filter, StringComparison comparisonType)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return query;

            return query.Where(q => propertyToFilter.Compile().Invoke(q).IndexOf(filter, comparisonType) >= 0);
        }

        public static IQueryable<T> ApplyEqualsFilter<T>(this IQueryable<T> query, Expression<Func<T, string>> propertyToFilter, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return query;

            return query.Where(q => propertyToFilter.Compile().Invoke(q).Equals(filter));
        }

        public static IQueryable<T> ApplyEqualsFilter<T>(this IQueryable<T> query, Expression<Func<T, string>> propertyToFilter, string filter, StringComparison comparisonType)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return query;

            return query.Where(q => propertyToFilter.Compile().Invoke(q).Equals(filter, comparisonType));
        }
    }
}