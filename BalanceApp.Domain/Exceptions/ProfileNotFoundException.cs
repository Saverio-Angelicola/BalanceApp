namespace BalanceApp.Domain.Exceptions
{
    public class ProfileNotFoundException : Exception
    {
        public ProfileNotFoundException(string id) : base($"Profile with id {id} not found") { }
    }
}
