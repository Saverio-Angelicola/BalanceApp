using BalanceApp.Application.Dtos.Users;
using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.interfaces.Users
{
    public interface IUserUpdaterService
    {
        Task<User> UpdateUser(string username, UpdateUserDto updatedUser);
        Task<User> UpdatePassword(string username, UpdateUserPasswordDto passwordDto);

    }
}
