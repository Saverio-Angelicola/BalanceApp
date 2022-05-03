using BalanceApp.Application.Dtos.Auth;

namespace BalanceApp.Application.Services.interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthTokenDto> Login(LoginDto loginUser);
    }
}
