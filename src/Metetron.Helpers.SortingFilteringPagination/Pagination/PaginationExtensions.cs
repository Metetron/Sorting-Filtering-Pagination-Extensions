using System;
using System.Linq;
using System.Threading.Tasks;
using Metetron.Helpers.SortingFilteringPagination.QueryObjects;
using Microsoft.EntityFrameworkCore;
using static System.Math;

namespace Metetron.Helpers.SortingFilteringPagination.Pagination
{
    public static class PaginationExtensions
    {
        private const int DefaultPageSize = 10;
        private const int DefaultCurrentPage = 1;

        private static IQueryable<T> PageData<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            return query.Skip((queryObj.CurrentPage - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }

        private static int GetPageCount(int numberOfItems, int pageSize)
        {
            return (int)Ceiling(numberOfItems / (1.00 * pageSize));
        }

        public static QueryResult<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj == null)
                throw new ArgumentNullException(nameof(queryObj));

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = DefaultPageSize;

            if (queryObj.CurrentPage <= 0)
                queryObj.CurrentPage = DefaultCurrentPage;

            return new QueryResult<T>
            {
                ResultSet = query.PageData(queryObj).ToList(),
                TotalNumberOfPages = GetPageCount(query.Count(), queryObj.PageSize)
            };
        }

        public static async Task<QueryResult<T>> ApplyPagingAsync<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj == null)
                throw new ArgumentNullException(nameof(queryObj));

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = DefaultPageSize;

            if (queryObj.CurrentPage <= 0)
                queryObj.CurrentPage = DefaultCurrentPage;

            return new QueryResult<T>
            {
                ResultSet = await query.PageData(queryObj).ToListAsync(),
                TotalNumberOfPages = GetPageCount(await query.CountAsync(), queryObj.PageSize)
            };
        }
    }
}