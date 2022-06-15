using SalveApp.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SalveApp.DAL.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
            where TKey : IEquatable<TKey>;
    }
}
