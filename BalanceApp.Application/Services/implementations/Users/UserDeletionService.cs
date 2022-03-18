using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.implementations.Users
{
    public class UserDeletionService : IUserDeletionService
    {
        private readonly IUserRepository userRepository;

        public UserDeletionService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> DeleteUser(string email)
        {
            User user = await userRepository.FindByEmail(email);
            await userRepository.Delete(user);
            return user;
        }
    }
}
