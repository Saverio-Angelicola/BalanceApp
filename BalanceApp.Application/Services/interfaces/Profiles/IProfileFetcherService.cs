using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.interfaces.Profiles
{
    public interface IProfileFetcherService
    {
        Task<Profile> GetProfile(string userEmail, Guid ProfileId);
        Task<List<Profile>> GetAllProfiles(string userEmail);
    }
}
