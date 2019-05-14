using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Metetron.Helpers.SortingFilteringPagination.QueryObjects;

namespace Metetron.Helpers.SortingFilteringPagination.Sorting
{
    public static class SortingExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IDictionary<string, Expression<Func<T, object>>> columnMapping, IQueryObject queryObj)
        {
            if (columnMapping == null)
                throw new ArgumentNullException(nameof(columnMapping));

            if (queryObj == null)
                throw new ArgumentNullException(nameof(queryObj));

            if (string.IsNullOrWhiteSpace(queryObj.SortBy) || !columnMapping.ContainsKey(queryObj.SortBy))
                return query;

            if (queryObj.IsSortAscending)
                return query.OrderBy(columnMapping[queryObj.SortBy]);

            return query.OrderByDescending(columnMapping[queryObj.SortBy]);
        }
    }
}