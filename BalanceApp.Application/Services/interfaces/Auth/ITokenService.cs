using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Services.interfaces.Auth
{
    public interface ITokenService
    {
        TokenDto CreateJwtToken(User user);
        string GetUsernameFromJwtToken(string bearerToken);
    }
}
