using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Application.Services.Providers;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BalanceApp.Application.Services.implementations.Users
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IDateTimeProvider dateTimeProvider;

        public UserRegistrationService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IDateTimeProvider dateTimeProvider)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task<User> RegisterUser(CreateUserDto createdUser)
        {
            User user = new(Guid.NewGuid(), createdUser.FirstName, createdUser.LastName, createdUser.Email, createdUser.Password, createdUser.BirthDate, dateTimeProvider.GetUtcNow());
            user.UpdatePassword(passwordHasher.HashPassword(user, createdUser.Password));
            return await userRepository.Create(user);
        }
    }
}
