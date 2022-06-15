using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.Users
{
    public class UserFetcherService : IUserFetcherService
    {
        private readonly IUserRepository userRepository;

        public UserFetcherService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await userRepository.FindAll();
        }

        public async Task<User> GetUserById(EntityId id)
        {
            return await userRepository.FindById(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await userRepository.FindByEmail(email);
        }
    }
}
