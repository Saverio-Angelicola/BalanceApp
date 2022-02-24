using BalanceApp.API.Dtos.Auth;
using BalanceApp.API.Entities;
using BalanceApp.API.Services.interfaces.Auth;
using BalanceApp.API.Services.interfaces.Users;
using Microsoft.AspNetCore.Identity;

namespace BalanceApp.API.Services.implementations.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService tokenService;
        private readonly IUserService userService;
        private readonly IPasswordHasher<User> passwordHasher;

        public AuthService(ITokenService tokenService, IUserService userService, IPasswordHasher<User> passwordHasher)
        {
            this.tokenService = tokenService;
            this.userService = userService;
            this.passwordHasher = passwordHasher;
        }

        public async Task<TokenDto> Login(LoginDto loginUser)
        {
            try
            {
                User user = await userService.GetUserByUsername(loginUser.UserName);
                PasswordVerificationResult isPasswordValid = passwordHasher.VerifyHashedPassword(user, user.UserPassword, loginUser.Password);

                if (isPasswordValid != PasswordVerificationResult.Success)
                {
                    throw new Exception("Password not valid!");
                }

                return tokenService.CreateJwtToken(user);
            }
            catch (Exception)
            {
                throw new Exception("Unauthorized");
            }

        }
    }
}
