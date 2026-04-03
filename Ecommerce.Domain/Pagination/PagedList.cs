namespace Ecommerce.Domain.Pagination;

public class PagedList<T> : List<T>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public PagedList(IEnumerable<T> items, int totalCount, int pageSize, int pageNumber)
    {
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        PageSize = pageSize;
        TotalCount = totalCount;
        AddRange(items);
    }

    public PagedList(IEnumerable<T> items, int currentPage, int totalPages, int pageSize, int pageNumber)
    {
        CurrentPage = currentPage;
        TotalPages = totalPages;
        PageSize = pageSize;
        TotalCount = totalPages;
        AddRange(items);
    }
}