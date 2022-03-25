using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BalanceApp.Application.Services.implementations.Users
{
    public class UserUpdaterService : IUserUpdaterService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;

        public UserUpdaterService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task<User> UpdatePassword(string email, UpdateUserPasswordDto passwordDto)
        {

            User user = await userRepository.FindByEmail(email);
            PasswordVerificationResult isPasswordValid = passwordHasher.VerifyHashedPassword(user, user.UserPassword, passwordDto.CurrentPassword);

            if (isPasswordValid != PasswordVerificationResult.Success)
            {
                throw new PasswordNotValidException();
            }
            user.UpdatePassword(passwordHasher.HashPassword(user, passwordDto.NewPassword));
            return await userRepository.Update(user);
        }

        public async Task<User> UpdateUser(string email, UpdateUserDto updatedUser)
        {
            User user = await userRepository.FindByEmail(email);

            if (updatedUser.FirstName?.Length > 0)
            {
                user.Firstname = updatedUser.FirstName;
            }

            if (updatedUser.LastName?.Length > 0)
            {
                user.Lastname = updatedUser.LastName;
            }

            await userRepository.Update(user);
            return user;
        }
    }
}
