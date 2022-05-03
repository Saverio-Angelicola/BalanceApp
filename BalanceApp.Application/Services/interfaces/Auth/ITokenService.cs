using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.interfaces.Auth
{
    public interface ITokenService
    {
        string CreateJwtToken(User user);
        string GetEmailFromJwtToken(string bearerToken);
    }
}
