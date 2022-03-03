using BalanceApp.Application.Repositories;
using BalanceApp.Domain.Entities;
using BalanceApp.Infrastructure.Datas.Contexts;
using BalanceApp.Infrastructure.Exceptions;
using BalanceApp.Infrastructure.Repositories.implementations;
using Microsoft.EntityFrameworkCore;

namespace BalanceApp.Infrastructure.Repositories
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
            try
            {
                return _context.Set<User>().Where(user => user.UserName == username).FirstAsync();
            }
            catch (Exception)
            {
                throw new UserNotFoundException(username);
            }
            
        }
    }
}
