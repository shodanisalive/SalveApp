using Microsoft.EntityFrameworkCore;
using SalveApp.DAL.Extensions;
using SalveApp.Infrastructure;
using SalveApp.Infrastructure.Responses;
using SalveApp.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SalveApp.DAL.Repositories.Impl
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(EFContext context)
        {
            dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await dbSet.FindAsync(id, cancellationToken);
        }

        public virtual async Task<ListResponse<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression = default,
            SortingOptions sortingOptions = default,
            PagingOptions pagingOptions = default,
            CancellationToken cancellationToken = default)
        {
            var q = dbSet.AsQueryable();

            if (expression != null)
            {
                q = q.Where(expression);
            }

            var count = q.Count();

            if (sortingOptions != null)
            {
                q = q.OrderBy(sortingOptions.GetOrderByClause());
            }

            if (pagingOptions != null)
            {
                q = q.Skip(pagingOptions.PageIndex * pagingOptions.PageSize)
                    .Take(pagingOptions.PageSize);
            }

            return new ListResponse<TEntity>() {
                Count = count,
                List = await q.ToListAsync(cancellationToken)
            };
        }
    }
}
