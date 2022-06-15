using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Providers;
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
        private readonly IWithingsProvider withingsProvider;

        public UserRegistrationService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IDateTimeProvider dateTimeProvider, IWithingsProvider withingsProvider)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.dateTimeProvider = dateTimeProvider;
            this.withingsProvider = withingsProvider;
        }

        public async Task<User> RegisterUser(CreateUserDto createdUser)
        {
            try
            {
                User user = new(Guid.NewGuid(), createdUser.FirstName, createdUser.LastName, createdUser.Email, createdUser.Password, createdUser.BirthDate, dateTimeProvider.GetUtcNow());
                user.UpdatePassword(passwordHasher.HashPassword(user, createdUser.Password));
                user.LastUpdate = "1";
                return await userRepository.Create(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> RegisterDoctor(CreateDoctorDto createdDoctor)
        {
            try
            {
                User user = new(Guid.NewGuid(), createdDoctor.FirstName, createdDoctor.LastName, createdDoctor.Email, createdDoctor.Password, createdDoctor.BirthDate, dateTimeProvider.GetUtcNow());
                user.UpdatePassword(passwordHasher.HashPassword(user, createdDoctor.Password));
                user.UpdateRole(createdDoctor.Role);
                return await userRepository.Create(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task RegisterRefreshToken(string email, string code)
        {
            try
            {
                User user = await userRepository.FindByEmail(email);
                var token = await withingsProvider.Login(code);
                user.RegisterRefreshToken(token.RefreshToken);
                await userRepository.Update(user);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
