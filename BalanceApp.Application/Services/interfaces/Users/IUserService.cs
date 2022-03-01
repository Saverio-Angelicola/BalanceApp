using BalanceApp.Application.Dtos.Users;
using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.interfaces.Users
{
    public interface IUserService
    {
        Task<User> GetUserByUsername(string username);
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(Guid id);
        Task<User> CreateUser(CreateUserDto createdUser);
        Task<User> UpdateUser(string username, UpdateUserDto updatedUser);
        Task<User> UpdatePassword(string username, UpdateUserPasswordDto passwordDto);
        Task<User> DeleteUser(string username);

    }
}
