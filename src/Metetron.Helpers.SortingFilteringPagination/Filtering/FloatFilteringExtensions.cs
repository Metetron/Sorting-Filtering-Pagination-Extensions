using System;
using System.Linq;
using System.Linq.Expressions;
using static System.Math;

namespace Metetron.Helpers.SortingFilteringPagination.Filtering
{
    public static class FloatFilteringExtensions
    {
        public static IQueryable<T> ApplyGreaterThanFilter<T>(this IQueryable<T> query, Expression<Func<T, float>> propertyToFilter, float constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) > constant);
        }

        public static IQueryable<T> ApplyGreaterThanOrEqualToFilter<T>(this IQueryable<T> query, Expression<Func<T, float>> propertyToFilter, float constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) >= constant);
        }

        public static IQueryable<T> ApplySmallerThanFilter<T>(this IQueryable<T> query, Expression<Func<T, float>> propertyToFilter, float constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) < constant);
        }

        public static IQueryable<T> ApplySmallerThanOrEqualToFilter<T>(this IQueryable<T> query, Expression<Func<T, float>> propertyToFilter, float constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) <= constant);
        }

        public static IQueryable<T> ApplyEqualToFilter<T>(this IQueryable<T> query, Expression<Func<T, float>> propertyToFilter, float constant, float delta = 1e-5f)
        {
            return query.Where(q => Abs(propertyToFilter.Compile().Invoke(q) - constant) <= delta);
        }
    }
}