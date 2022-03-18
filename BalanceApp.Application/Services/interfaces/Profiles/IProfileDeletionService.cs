namespace BalanceApp.Application.Services.interfaces.Profiles
{
    public interface IProfileDeletionService
    {
        void DeleteProfile(string userEmail, Guid profileId);
    }
}
