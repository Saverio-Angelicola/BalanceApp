using BalanceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BalanceApp.Infrastructure.Datas.Contexts
{
    public interface IContext
    {
        DbSet<User>? Users { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
