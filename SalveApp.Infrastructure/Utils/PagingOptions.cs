namespace SalveApp.Infrastructure.Utils
{
    public class PagingOptions
    {
        public PagingOptions(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public int PageIndex { get; }
        public int PageSize { get; }
    }
}
