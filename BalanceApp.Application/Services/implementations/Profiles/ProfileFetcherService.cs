using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Profiles;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.Profiles
{
    public class ProfileFetcherService : IProfileFetcherService
    {
        private readonly IUserRepository userFetcherRepository;

        public ProfileFetcherService(IUserRepository userFetcherRepository)
        {
            this.userFetcherRepository = userFetcherRepository;
        }
        public async Task<Profile> GetProfile(string userEmail, Guid ProfileId)
        {
            User? user = await userFetcherRepository.FindByEmail(userEmail);
            if (user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            return user.GetProfile(ProfileId);
        }

        public async Task<List<Profile>> GetAllProfiles(string userEmail)
        {
            User? user = await userFetcherRepository.FindByEmail(userEmail);
            if (user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            return user.Profiles;
        }
    }
}
