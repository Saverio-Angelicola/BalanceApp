using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Providers
{
    public interface IWithingsProvider
    {
        Task<WithingsTokenDto> Login(string code);
        Task<WithingsTokenDto> RefreshToken(string token);
        Task<List<BodyData>> GetMeasures(string withingsToken, string startDate,double height);

    }
}
