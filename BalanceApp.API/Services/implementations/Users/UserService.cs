using BalanceApp.API.Dtos.Users;
using BalanceApp.API.Entities;
using BalanceApp.API.Repositories.interfaces;
using BalanceApp.API.Services.interfaces.Users;
using BalanceApp.API.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace BalanceApp.API.Services.implementations.Users
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
            User user = new(Guid.NewGuid(),createdUser.FirstName, createdUser.LastName, createdUser.Username, string.Empty);
            user.Password = passwordHasher.HashPassword(user, createdUser.Password);
            return await userRepository.Create(user);
        }

        public async Task<User> DeleteUser(string username)
        {
            User user = await userRepository.FindByUsername(username);
            return await userRepository.Delete(user);

        }

        public async Task<List<User>> GetAllUser()
        {
            return await userRepository.FindAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await userRepository.FindById(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await userRepository.FindByUsername(username);
        }

        public async Task<User> UpdatePassword(string username, UpdateUserPasswordDto passwordDto)
        {
            if (passwordDto.CurrentPassword.Length <= 0 && passwordDto.NewPassword.Length <= 0)
            {
                throw new Exception("Current passsword and new password is empty !");
            }

            User user = await userRepository.FindByUsername(username);
            PasswordVerificationResult isPasswordValid = passwordHasher.VerifyHashedPassword(user, user.Password, passwordDto.CurrentPassword);

            if (isPasswordValid != PasswordVerificationResult.Success)
            {
                throw new Exception("Password not valid !");
            }

            user.Password = passwordHasher.HashPassword(user, passwordDto.NewPassword);
            return await userRepository.Update(user);
        }

        public async Task<User> UpdateUser(string username, UpdateUserDto updatedUser)
        {
            User user = await userRepository.FindByUsername(username);

            if (updatedUser.FirstName?.Length > 0)
            {
                user.FirstName = updatedUser.FirstName;
            }

            if (updatedUser.LastName?.Length > 0)
            {
                user.LastName = updatedUser.LastName;
            }

            return await userRepository.Update(user);
        }
    }
}
