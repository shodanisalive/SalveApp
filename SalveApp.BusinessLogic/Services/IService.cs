using SalveApp.Infrastructure;
using SalveApp.Infrastructure.Responses;
using SalveApp.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SalveApp.BusinessLogic.Services
{
    public interface IService<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<ListResponse<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression = default,
            SortingOptions sortingOptions = default,
            PagingOptions pagingOptions = default,
            CancellationToken cancellationToken = default);
    }
}
