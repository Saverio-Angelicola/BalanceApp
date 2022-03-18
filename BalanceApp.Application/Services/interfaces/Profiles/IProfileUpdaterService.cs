using BalanceApp.Application.Dtos.Profiles;

namespace BalanceApp.Application.Services.interfaces.Profiles
{
    public interface IProfileUpdaterService
    {
        void UpdateProfile(string userEmail, Guid ProfileId, UpdateProfileDto updateProfileDto);
    }
}
