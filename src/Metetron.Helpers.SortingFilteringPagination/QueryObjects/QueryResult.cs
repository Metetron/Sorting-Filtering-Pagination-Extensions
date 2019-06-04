using System.Collections.Generic;

namespace Metetron.Helpers.SortingFilteringPagination.QueryObjects
{
    public class QueryResult<T>
    {
        public IEnumerable<T> ResultSet { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumberOfPages { get; set; }
    }
}