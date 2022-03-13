using BalanceApp.Application.Datas;
using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BalanceApp.Application.Services.implementations.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task<User> CreateUser(CreateUserDto createdUser)
        {
            User user = new(Guid.NewGuid(), createdUser.FirstName, createdUser.LastName, createdUser.Email, createdUser.Password);
            user.UpdatePassword(passwordHasher.HashPassword(user, createdUser.Password));
            await userRepository.Create(user);
            return user;
        }

        public async Task<User> DeleteUser(string email)
        {
            User user = await userRepository.FindByEmail(email);
            await userRepository.Delete(user);
            return user;

        }

        public async Task<List<User>> GetAllUser()
        {
            return await userRepository.FindAll();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await userRepository.FindById(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await userRepository.FindByEmail(email);
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
            await userRepository.Update(user);
            return user;
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
