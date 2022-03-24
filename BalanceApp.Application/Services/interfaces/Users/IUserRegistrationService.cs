using BalanceApp.Application.Dtos.Users;
using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.interfaces.Users
{
    public interface IUserRegistrationService
    {
        Task<User> RegisterUser(CreateUserDto createdUser);
    }
}
