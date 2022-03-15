using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Profiles;
using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.implementations.Profiles
{
    public class ProfileDeletionService : IProfileDeletionService
    {
        private readonly IUserRepository userRepository;

        public ProfileDeletionService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async void DeleteProfile(string userEmail, Guid profileId)
        {
            User? user = await userRepository.FindByEmail(userEmail);
            if (user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            user.DeleteProfile(profileId);
            await userRepository.Update(user);
        }
    }
}
