using BalanceApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BalanceApp.API.Datas
{
    public interface IContext
    {
        DbSet<User>? Users { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
