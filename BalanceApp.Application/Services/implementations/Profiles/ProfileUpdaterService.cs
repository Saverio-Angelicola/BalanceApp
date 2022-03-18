using BalanceApp.Application.Dtos.Profiles;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Profiles;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.Profiles
{
    public class ProfileUpdaterService : IProfileUpdaterService
    {
        private readonly IUserRepository userRepository;

        public ProfileUpdaterService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async void UpdateProfile(string userEmail, Guid ProfileId, UpdateProfileDto updateProfileDto)
        {
            User? user = await userRepository.FindByEmail(userEmail);
            if (user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            Profile profile = user.GetProfile(ProfileId);

            if (updateProfileDto.Firstname is not null)
            {
                profile.Firstname = updateProfileDto.Firstname;
            }

            if (updateProfileDto.Lastname is not null)
            {
                profile.Lastname = updateProfileDto.Lastname;
            }

            if (updateProfileDto.Height is not double.NaN)
            {
                profile.Height = updateProfileDto.Height;
            }

            if (updateProfileDto.Gender <= 1 && updateProfileDto.Gender >= 0)
            {
                profile.Gender = updateProfileDto.Gender;
            }

            user.UpdateProfile(profile.Id, profile);
            await userRepository.Update(user);
        }
    }
}
