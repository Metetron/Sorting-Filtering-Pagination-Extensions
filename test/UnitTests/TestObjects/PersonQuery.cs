using Metetron.Helpers.SortingFilteringPagination.QueryObjects;

namespace UnitTests.TestObjects
{
    public class PersonQuery : IQueryObject
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }

        public string ForeName { get; set; }
        public string SirName { get; set; }
        public string Email { get; set; }
    }
}