using BalanceApp.API.Entities;

namespace BalanceApp.API.Repositories.interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByUsername(string username);
    }
}
