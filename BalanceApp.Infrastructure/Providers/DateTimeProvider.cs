using BalanceApp.Application.Services.Providers;

namespace BalanceApp.Infrastructure.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow() => DateTime.Now;
        public DateTime GetUtcNow() => DateTime.UtcNow;
    }
}
