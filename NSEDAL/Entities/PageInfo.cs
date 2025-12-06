namespace NSEDAL.Entities
{
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public PageInfo() { }

        public PageInfo(int pageNumber, int pageSize, string sortColumn, string sortOrder)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SortColumn = sortColumn;
            SortOrder = sortOrder;
        }
    }
}