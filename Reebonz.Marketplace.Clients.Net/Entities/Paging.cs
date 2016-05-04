
namespace Reebonz.Marketplace.Clients.Net.Entities
{
    public class PagingJson
    {
        public PagingJson()
        { }

        public PagingJson(PagingStatus pagingStatus)
        {
            PageNumber = pagingStatus.PageNumber;
            PageSize = pagingStatus.PageSize;
            TotalItems = pagingStatus.TotalItems;
            TotalPages = pagingStatus.TotalPages;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }

    public class PageRequestJson
    {
        /// <summary>
        /// Page number of results you want returned, defaults to 1
        /// </summary>
        public int? PageNumber { get; set; }
        /// <summary>
        /// Page size you want returned, defaults to 25, max 100
        /// </summary>
        public int? PageSize { get; set; }
    }

    public class PageAndSortJsonRequest : PageRequestJson
    {
        /// <summary>
        /// Specify the field you want to sort on, options are SortOrder (default), SalesRank, Follows, 
        /// Discount (amount product is discounted from RRP price), Created (date product was created) and Prices (list price).
        /// </summary>
        public string SortBy { get; set; }
        /// <summary>
        /// Sort the results in descending order (default is false)
        /// </summary>
        public bool? SortDesc { get; set; }
    }

    public class PagingStatus
    {
        public PagingStatus()
        { }

        public PagingStatus(int pageSize, int pageNumber, int totalRecords)
        {
            TotalItems = totalRecords;
            PageSize = pageSize == 0 ? 1024 : pageSize;
            PageNumber = pageNumber == 0 ? 1 : pageNumber;

            int pageCount = TotalItems / PageSize + (TotalItems % PageSize == 0 ? 0 : 1);

            FirstItem = ((PageNumber - 1) * PageSize) + 1;
            HasNextPage = PageNumber < pageCount;
            HasPreviousPage = PageNumber > 1;
            LastItem = PageNumber < pageCount ? ((PageNumber - 1) * PageSize) + PageSize : TotalItems;
            TotalPages = pageCount;
        }

        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int FirstItem { get; private set; }
        public int LastItem { get; private set; }
        public bool HasNextPage { get; private set; }
        public bool HasPreviousPage { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
    }

    public class Pages
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public Pages(int pageNumber, int pageSize, int totalResults)
        {
            pageSize = pageSize <= 0 ? 10 : pageSize;
            PageNumber = pageNumber;
            TotalPages = (totalResults / pageSize) + (totalResults % pageSize == 0 ? 0 : 1);
        }
    }
}