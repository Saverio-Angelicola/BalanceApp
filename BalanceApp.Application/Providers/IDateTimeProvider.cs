namespace BalanceApp.Application.Services.Providers
{
    public interface IDateTimeProvider
    {
        DateTime GetNow();
        DateTime GetUtcNow();
    }
}
