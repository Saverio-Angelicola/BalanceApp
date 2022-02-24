using BalanceApp.API.Datas.Contexts;
using BalanceApp.API.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace BalanceApp.API.Repositories.implementations
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IContext _context;

        protected Repository(IContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> FindAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> FindById(int id)
        {
           TEntity? entity =  await _context.Set<TEntity>().FindAsync(id);
            if (entity is null)
                throw new ArgumentException("entity is null");
           return entity;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return entity;
        }
    }
}
