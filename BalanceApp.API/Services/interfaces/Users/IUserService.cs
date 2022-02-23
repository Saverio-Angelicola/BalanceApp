using BalanceApp.API.Dtos.Users;
using BalanceApp.API.Entities;
using BalanceApp.API.ValueObjects;

namespace BalanceApp.API.Services.interfaces.Users
{
    public interface IUserService
    {
        Task<User> GetUserByUsername(string username);
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(CreateUserDto createdUser);
        Task<User> UpdateUser(string username, UpdateUserDto updatedUser);
        Task<User> UpdatePassword(string username, UpdateUserPasswordDto passwordDto);
        Task<User> DeleteUser(string username);

    }
}
