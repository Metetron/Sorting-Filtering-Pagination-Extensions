namespace Metetron.Helpers.SortingFilteringPagination.QueryObjects
{
    public interface IQueryObject
    {
        int PageSize { get; set; }
        int CurrentPage { get; set; }
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
    }
}