using Microsoft.EntityFrameworkCore;
using SalveApp.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SalveApp.DAL.Repositories.Impl
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EFContext context;

        public UnitOfWork(EFContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return new BaseRepository<TEntity, TKey>(context);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
