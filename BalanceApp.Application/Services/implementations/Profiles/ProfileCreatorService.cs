using BalanceApp.Application.Dtos.Profiles;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Profiles;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.Profiles
{
    public class ProfileCreatorService : IProfileCreatorService
    {
        private readonly IUserRepository userRepository;

        public ProfileCreatorService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async void CreateProfile(string userEmail, CreateProfileDto profileDto)
        {
            User? user = await userRepository.FindByEmail(userEmail);
            if (user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            Profile profile = new(Guid.NewGuid(), profileDto.Firstname, profileDto.Lastname, profileDto.Gender, profileDto.BirthDate, profileDto.Height);
            user.AddProfile(profile);
            await userRepository.Update(user);
        }
    }
}
