using SalveApp.DAL.Repositories;
using SalveApp.Infrastructure;
using SalveApp.Infrastructure.Responses;
using SalveApp.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SalveApp.BusinessLogic.Services.Impl
{
    public class BaseService<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected IUnitOfWork unitOfWork;
        protected IRepository<TEntity, TKey> repository;
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.GetRepository<TEntity, TKey>();
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            repository.Add(entity);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            repository.Update(entity);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            repository.Delete(entity);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await repository.GetByIdAsync(id, cancellationToken);
        }

        public virtual async Task<ListResponse<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression = default,
            SortingOptions sortingOptions = default,
            PagingOptions pagingOptions = default,
            CancellationToken cancellationToken = default)
        {
            return await repository.ListAsync(expression, sortingOptions, pagingOptions, cancellationToken);
        }
    }
}
