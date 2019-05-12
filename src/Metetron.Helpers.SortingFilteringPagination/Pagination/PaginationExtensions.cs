using System.Linq;
using System.Threading.Tasks;
using Metetron.Helpers.SortingFilteringPagination.QueryObjects;
using Microsoft.EntityFrameworkCore;
using static System.Math;

namespace Metetron.Helpers.SortingFilteringPagination.Pagination
{
    public static class PaginationExtensions
    {
        private static IQueryable<T> PageData<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 1;

            if (queryObj.CurrentPage <= 0)
                queryObj.CurrentPage = 1;

            return query.Skip((queryObj.CurrentPage - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }

        private static int GetPageCount(int numberOfItems, int pageSize)
        {
            return (int)Ceiling(numberOfItems / (1.00 * pageSize));
        }

        public static QueryResult<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            var totalNumberOfPages = GetPageCount(query.Count(), queryObj.PageSize);

            return new QueryResult<T>
            {
                ResultSet = query.PageData(queryObj).ToList(),
                TotalNumberOfPages = totalNumberOfPages
            };
        }

        public static async Task<QueryResult<T>> ApplyPagingAsync<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            var totalNumberOfPages = GetPageCount(await query.CountAsync(), queryObj.PageSize);

            return new QueryResult<T>
            {
                ResultSet = await query.PageData(queryObj).ToListAsync(),
                TotalNumberOfPages = totalNumberOfPages
            };
        }
    }
}