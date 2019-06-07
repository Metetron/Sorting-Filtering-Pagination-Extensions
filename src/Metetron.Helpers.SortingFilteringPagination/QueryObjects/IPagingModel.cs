namespace Metetron.Helpers.SortingFilteringPagination.QueryObjects
{
    public interface IPagingModel
    {
        int CurrentPage { get; set; }
        int TotalNumberOfPages { get; set; }
    }
}