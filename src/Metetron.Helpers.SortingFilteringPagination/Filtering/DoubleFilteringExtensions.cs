using System;
using System.Linq;
using System.Linq.Expressions;
using static System.Math;

namespace Metetron.Helpers.SortingFilteringPagination.Filtering
{
    public static class DoubleFilteringExtensions
    {
        /// <summary>
        /// Applies a 'greater than'- filter to the query
        /// </summary>
        /// <param name="query">The IQueryable to query</param>
        /// <param name="propertyToFilter">The property to query</param>
        /// <param name="constant">The value to compare against</param>
        /// <typeparam name="T">The type of object to query</typeparam>
        /// <returns>The filtered IQueryable</returns>
        public static IQueryable<T> ApplyGreaterThanFilter<T>(this IQueryable<T> query, Expression<Func<T, double>> propertyToFilter, double constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) > constant);
        }

        /// <summary>
        /// Applies a 'greater than or equal to'- filter to the query
        /// </summary>
        /// <param name="query">The IQueryable to query</param>
        /// <param name="propertyToFilter">The property to query</param>
        /// <param name="constant">The value to compare against</param>
        /// <typeparam name="T">The type of object to query</typeparam>
        /// <returns>The filtered IQueryable</returns>
        public static IQueryable<T> ApplyGreaterThanOrEqualToFilter<T>(this IQueryable<T> query, Expression<Func<T, double>> propertyToFilter, double constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) >= constant);
        }

        /// <summary>
        /// Applies a 'smaller than'- filter to the query
        /// </summary>
        /// <param name="query">The IQueryable to query</param>
        /// <param name="propertyToFilter">The property to query</param>
        /// <param name="constant">The value to compare against</param>
        /// <typeparam name="T">The type of object to query</typeparam>
        /// <returns>The filtered IQueryable</returns>
        public static IQueryable<T> ApplySmallerThanFilter<T>(this IQueryable<T> query, Expression<Func<T, double>> propertyToFilter, double constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) < constant);
        }

        /// <summary>
        /// Applies a 'smaller than or equal to'- filter to the query
        /// </summary>
        /// <param name="query">The IQueryable to query</param>
        /// <param name="propertyToFilter">The property to query</param>
        /// <param name="constant">The value to compare against</param>
        /// <typeparam name="T">The type of object to query</typeparam>
        /// <returns>The filtered IQueryable</returns>
        public static IQueryable<T> ApplySmallerThanOrEqualToFilter<T>(this IQueryable<T> query, Expression<Func<T, double>> propertyToFilter, double constant)
        {
            return query.Where(q => propertyToFilter.Compile().Invoke(q) <= constant);
        }

        /// <summary>
        /// Applies an 'equal to'- filter to the query
        /// </summary>
        /// <param name="query">The IQueryable to query</param>
        /// <param name="propertyToFilter">The property to query</param>
        /// <param name="constant">The value to compare against</param>
        /// <param name="delta">The allowed deviation from zero</param>
        /// <typeparam name="T">The type of object to query</typeparam>
        /// <returns>The filtered IQueryable</returns>
        public static IQueryable<T> ApplyEqualToFilter<T>(this IQueryable<T> query, Expression<Func<T, double>> propertyToFilter, double constant, double delta = 1e-5d)
        {
            return query.Where(q => Abs(propertyToFilter.Compile().Invoke(q) - constant) <= delta);
        }
    }
}