using BalanceApp.Application.Dtos.Profiles;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.Users
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserRepository userRepository;

        public UserProfileService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async void AddProfile(string userEmail, CreateProfileDto profileDto)
        {
            User? user = await userRepository.FindByEmail(userEmail);
            if(user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            Profile profile = new(Guid.NewGuid(), profileDto.Firstname, profileDto.Lastname, profileDto.Gender, profileDto.BirthDate, profileDto.Height);
            user.AddProfile(profile);
            userRepository.Update(user);
        }

        public async Task<Profile> GetProfile(string userEmail, Guid ProfileId)
        {
            User? user = await userRepository.FindByEmail(userEmail);
            if (user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            return user.GetProfile(ProfileId);
        }

        public async Task<List<Profile>> GetAllProfiles(string userEmail)
        {
            User? user = await userRepository.FindByEmail(userEmail);
            if (user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            return user.Profiles;
        }

        public async void DeleteProfile(string userEmail, Guid profileId)
        {
            User? user = await userRepository.FindByEmail(userEmail);
            if (user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            user.DeleteProfile(profileId);
            userRepository.Update(user);
        }

        public async void UpdateProfile(string userEmail, Guid ProfileId, UpdateProfileDto updateProfileDto)
        {
            User? user = await userRepository.FindByEmail(userEmail);
            if (user is null)
            {
                throw new UserNotFoundException(userEmail);
            }
            Profile profile = user.GetProfile(ProfileId);

            if(updateProfileDto.Firstname is not null)
            {
                profile.Firstname = updateProfileDto.Firstname;
            }

            if(updateProfileDto.Lastname is not null)
            {
                profile.Lastname = updateProfileDto.Lastname;
            }

            if(updateProfileDto.Height is not double.NaN)
            {
                profile.Height = updateProfileDto.Height;
            }

            if(updateProfileDto.Gender is not null)
            {
                profile.Gender = updateProfileDto.Gender;
            }

            user.UpdateProfile(profile.Id, profile);
            userRepository.Update(user);
        }
    }
}
