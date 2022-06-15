using SalveApp.Infrastructure;
using SalveApp.Infrastructure.Responses;
using SalveApp.Infrastructure.Utils;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SalveApp.DAL.Repositories
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<ListResponse<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression = default,
            SortingOptions sortingOptions = default,
            PagingOptions pagingOptions = default,
            CancellationToken cancellationToken = default);
    }
}
