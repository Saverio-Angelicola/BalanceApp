using BalanceApp.API.Dtos.Auth;

namespace BalanceApp.API.Services.interfaces.Auth
{
    public interface IAuthService
    {
        Task<TokenDto> Login(LoginDto loginUser);
    }
}
