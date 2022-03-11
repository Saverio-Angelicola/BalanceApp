using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BalanceApp.Application.Services.implementations.Auth
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
                User user = await userService.GetUserByEmail(loginUser.Email);
                PasswordVerificationResult isPasswordValid = passwordHasher.VerifyHashedPassword(user, user.UserPassword, loginUser.Password);

                if (isPasswordValid != PasswordVerificationResult.Success)
                {
                    throw new PasswordNotValidException();
                }

                return tokenService.CreateJwtToken(user);
            }
            catch (Exception)
            {
                throw new UnauthorizedAuthenticationException(loginUser.Email);
            }

        }
    }
}
