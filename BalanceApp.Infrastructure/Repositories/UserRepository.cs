using BalanceApp.Application.Repositories;
using BalanceApp.Domain.Entities;
using BalanceApp.Infrastructure.Datas;
using BalanceApp.Infrastructure.Exceptions;
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
        public Task<User> FindByEmail(string email)
        {
            try
            {
                return _context.Set<User>().Where(user => user.Email == email).FirstAsync();
            }
            catch (Exception)
            {
                throw new UserNotFoundException(email);
            }

        }
    }
}
