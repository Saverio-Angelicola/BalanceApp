using BalanceApp.Application.Dtos.Profiles;

namespace BalanceApp.Application.Services.interfaces.Profiles
{
    public interface IProfileCreatorService
    {
        void CreateProfile(string userEmail, CreateProfileDto profileDto);
    }
}
