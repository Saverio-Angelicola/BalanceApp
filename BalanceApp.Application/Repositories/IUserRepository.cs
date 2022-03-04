using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmail(string email);
    }
}
