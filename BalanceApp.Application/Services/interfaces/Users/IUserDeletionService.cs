using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.interfaces.Users
{
    public interface IUserDeletionService
    {
        Task<User> DeleteUser(string username);
    }
}
