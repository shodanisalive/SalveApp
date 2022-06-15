namespace SalveApp.Infrastructure.Utils
{
    public class SortingOptions
    {
        public SortingOptions(string column, bool isAscending)
        {
            Column = column;
            IsAscending = isAscending;
        }
        public string Column { get; }
        public bool IsAscending { get; }
    }
}
