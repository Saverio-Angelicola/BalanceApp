using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> FindAll();
        Task<TEntity> FindById(EntityId id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
    }
}
