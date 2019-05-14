using System;
using System.Linq;
using System.Linq.Expressions;

namespace Metetron.Helpers.SortingFilteringPagination.Filtering
{
    public static class IntegerFilteringExtensions
    {
        public static IQueryable<T> ApplyGreaterThanFilter<T>(this IQueryable<T> query, Expression<Func<T, int>> propertyToFilter, int constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) > constant);
        }

        public static IQueryable<T> ApplyGreaterThanOrEqualToFilter<T>(this IQueryable<T> query, Expression<Func<T, int>> propertyToFilter, int constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) >= constant);
        }

        public static IQueryable<T> ApplySmallerThanFilter<T>(this IQueryable<T> query, Expression<Func<T, int>> propertyToFilter, int constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) < constant);
        }

        public static IQueryable<T> ApplySmallerThanOrEqualToFilter<T>(this IQueryable<T> query, Expression<Func<T, int>> propertyToFilter, int constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) <= constant);
        }

        public static IQueryable<T> ApplyEqualToFilter<T>(this IQueryable<T> query, Expression<Func<T, int>> propertyToFilter, int constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) == constant);
        }
    }
}