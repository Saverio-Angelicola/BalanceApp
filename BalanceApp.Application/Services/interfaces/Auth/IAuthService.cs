using BalanceApp.Application.Dtos.Auth;

namespace BalanceApp.Application.Services.interfaces.Auth
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto loginUser);
    }
}
