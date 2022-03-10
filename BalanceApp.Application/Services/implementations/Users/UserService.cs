using BalanceApp.Application.Datas;
using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BalanceApp.Application.Services.implementations.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHasher<User> passwordHasher;

        public UserService(IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher)
        {
            this.unitOfWork = unitOfWork;
            this.passwordHasher = passwordHasher;
        }

        public async Task<User> CreateUser(CreateUserDto createdUser)
        {
            User user = new(Guid.NewGuid(),createdUser.FirstName,createdUser.LastName, createdUser.Email, createdUser.Password);
            user.UpdatePassword(passwordHasher.HashPassword(user, createdUser.Password));
            await unitOfWork.Users.Create(user);
            await unitOfWork.CompleteAsync();
            return user;
        }

        public async Task<User> DeleteUser(string email)
        {
            User user = await unitOfWork.Users.FindByEmail(email);
            unitOfWork.Users.Delete(user);
            await unitOfWork.CompleteAsync();
            return user;

        }

        public async Task<List<User>> GetAllUser()
        {
            return await unitOfWork.Users.FindAll();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await unitOfWork.Users.FindById(id);
        }

        public async Task<User> GetUserByUsername(string email)
        {
            return await unitOfWork.Users.FindByEmail(email);
        }

        public async Task<User> UpdatePassword(string email, UpdateUserPasswordDto passwordDto)
        {

            User user = await unitOfWork.Users.FindByEmail(email);
            PasswordVerificationResult isPasswordValid = passwordHasher.VerifyHashedPassword(user, user.UserPassword, passwordDto.CurrentPassword);

            if (isPasswordValid != PasswordVerificationResult.Success)
            {
                throw new PasswordNotValidException();
            }
            user.UpdatePassword(passwordHasher.HashPassword(user, passwordDto.NewPassword));
            unitOfWork.Users.Update(user);
            await unitOfWork.CompleteAsync();
            return user;
        }

        public async Task<User> UpdateUser(string email, UpdateUserDto updatedUser)
        {
            User user = await unitOfWork.Users.FindByEmail(email);

            if (updatedUser.FirstName?.Length > 0)
            {
                user.Firstname = updatedUser.FirstName;
            }

            if (updatedUser.LastName?.Length > 0)
            {
                user.Lastname = updatedUser.LastName;
            }

            unitOfWork.Users.Update(user);
            await unitOfWork.CompleteAsync();
            return user;
        }
    }
}
