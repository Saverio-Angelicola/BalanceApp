using BalanceApp.Application.Dtos.Users;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.interfaces.Users
{
    public interface IUserFetcherService
    {
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(EntityId id);
    }
}
