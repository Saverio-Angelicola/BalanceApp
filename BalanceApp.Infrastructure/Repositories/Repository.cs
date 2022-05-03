using BalanceApp.Application.Repositories;
using BalanceApp.Domain.Entities;
using BalanceApp.Infrastructure.Datas;
using BalanceApp.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BalanceApp.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
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

        public async Task<TEntity> FindById(Guid id)
        {
            TEntity? entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity is null)
            {
                throw new EntityNotFoundException(id);
            }

            return entity;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
