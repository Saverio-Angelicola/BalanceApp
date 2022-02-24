using BalanceApp.API.Datas.Contexts;
using BalanceApp.API.Entities;
using BalanceApp.API.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace BalanceApp.API.Repositories.implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IContext _context;

        public UserRepository(IContext context) : base(context)
        {
            _context = context;
        }
        public Task<User> FindByUsername(string username)
        {
            return _context.Set<User>().Where(user => user.UserName == username).FirstAsync();
        }
    }
}
