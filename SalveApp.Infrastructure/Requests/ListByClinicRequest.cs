namespace SalveApp.Infrastructure.Requests
{
    public class ListByClinicRequest
    {
        public int ClinicId { get; set; }
        public string SortingColumn { get; set; } = "Id";
        public bool SortAscending { get; set; } = true;
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 20;
    }
}
