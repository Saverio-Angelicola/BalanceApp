using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.interfaces.Users
{
    public interface IUserFetcherService
    {
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(Guid id);
    }
}
