using BalanceApp.API.Datas.Contexts;
using BalanceApp.API.Repositories.implementations;
using BalanceApp.API.Repositories.interfaces;

namespace BalanceApp.API.Datas.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;
        public IUserRepository Users { get; }

        public UnitOfWork(IContext context)
        {
            _context = context;
            Users = new UserRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
