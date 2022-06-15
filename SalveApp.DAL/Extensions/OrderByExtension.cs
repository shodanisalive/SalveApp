using SalveApp.Infrastructure.Utils;

namespace SalveApp.DAL.Extensions
{
    public static class OrderByExtension
    {
        internal static string GetOrderByClause(this SortingOptions sortingOptions)
        {
            return $"{sortingOptions.Column} {(sortingOptions.IsAscending ? "ASC" : "DESC")}";
        }
    }
}
