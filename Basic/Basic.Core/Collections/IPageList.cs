namespace Basic.Core.Collections
{
    public interface IPageList<T>
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }

        int TotalCount { get; set; }

        int PageNumber { get; set; }

        int TotalPages { get; set; }
    }
}
