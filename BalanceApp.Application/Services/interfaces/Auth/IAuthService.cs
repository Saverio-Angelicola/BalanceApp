using BalanceApp.Domain.Dtos.Auth;

namespace BalanceApp.Application.Services.interfaces.Auth
{
    public interface IAuthService
    {
        Task<TokenDto> Login(LoginDto loginUser);
    }
}
