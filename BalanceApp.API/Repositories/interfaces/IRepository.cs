namespace BalanceApp.API.Repositories.interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> FindAll();
        Task<TEntity> FindById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
    }
}
