using System.Collections.Generic;

namespace SalveApp.Infrastructure.Responses
{
    public class ListResponse<TEntity> where TEntity : IAggregateRoot
    {
        public int Count { get; set; }

        public ICollection<TEntity> List { get; set; }
    }
}
