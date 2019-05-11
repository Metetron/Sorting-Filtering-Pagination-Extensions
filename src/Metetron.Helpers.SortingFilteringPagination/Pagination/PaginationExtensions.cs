using System.Linq;
using System.Threading.Tasks;
using Metetron.Helpers.SortingFilteringPagination.QueryObjects;
using Microsoft.EntityFrameworkCore;

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
        public static QueryResult<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            var totalNumberOfPages = query.Count();

            return new QueryResult<T>
            {
                ResultSet = query.PageData(queryObj).ToList(),
                TotalNumberOfPages = totalNumberOfPages
            };
        }

        public static async Task<QueryResult<T>> ApplyPagingAsync<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            var totalNumberOfPages = await query.CountAsync();

            return new QueryResult<T>
            {
                ResultSet = await query.PageData(queryObj).ToListAsync(),
                TotalNumberOfPages = totalNumberOfPages
            };
        }
    }
}