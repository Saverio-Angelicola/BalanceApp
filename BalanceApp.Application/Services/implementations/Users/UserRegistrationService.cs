using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BalanceApp.Application.Services.implementations.Users
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;

        public UserRegistrationService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task<User> RegisterUser(CreateUserDto createdUser)
        {
            User user = new(Guid.NewGuid(), createdUser.FirstName, createdUser.LastName, createdUser.Email, createdUser.Password);
            user.UpdatePassword(passwordHasher.HashPassword(user, createdUser.Password));
            await userRepository.Create(user);
            return user;
        }
    }
}
