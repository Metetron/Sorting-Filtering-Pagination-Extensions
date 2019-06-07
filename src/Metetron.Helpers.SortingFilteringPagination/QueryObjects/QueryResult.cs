using System.Collections.Generic;

namespace Metetron.Helpers.SortingFilteringPagination.QueryObjects
{
    public class QueryResult<T> : IPagingModel
    {
        public IEnumerable<T> ResultSet { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumberOfPages { get; set; }
    }
}