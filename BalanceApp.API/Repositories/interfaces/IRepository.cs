namespace BalanceApp.API.Repositories.interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> FindAll();
        Task<TEntity> FindById(Guid id);
        Task<TEntity> Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
