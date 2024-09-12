namespace Store.Models;

public class PageInfo
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
    
}

public class IndexViewModel<T> : PageInfo
{
    public IEnumerable<T> Items { get; set; }
    public PageInfo PageInfo { get; set; }
}