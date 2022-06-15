using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.interfaces.Auth
{
    public interface ITokenService
    {
        string CreateJwtToken(User user, string withingsToken);
        string GetEmailFromJwtToken(string bearerToken);
        string GetWithingsTokenFromJwtToken(string bearerToken);
    }
}
