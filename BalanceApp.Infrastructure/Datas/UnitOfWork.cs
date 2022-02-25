using BalanceApp.Application.Datas;
using BalanceApp.Application.Repositories;
using BalanceApp.Infrastructure.Datas.Contexts;

namespace BalanceApp.API.Datas
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;
        public IUserRepository Users { get; }

        public UnitOfWork(IContext context, IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
