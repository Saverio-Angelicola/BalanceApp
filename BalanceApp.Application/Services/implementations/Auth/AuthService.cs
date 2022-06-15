using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Providers;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BalanceApp.Application.Services.implementations.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService tokenService;
        private readonly IUserFetcherService userFetcherService;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IWithingsProvider withingsProvider;
        private readonly IUserRepository userRepository;

        public AuthService(ITokenService tokenService, IUserFetcherService userFetcherService, IPasswordHasher<User> passwordHasher, IWithingsProvider withingsProvider, IUserRepository userRepository)
        {
            this.tokenService = tokenService;
            this.userFetcherService = userFetcherService;
            this.passwordHasher = passwordHasher;
            this.withingsProvider = withingsProvider;
            this.userRepository = userRepository;
        }

        public async Task<AuthTokenDto> Login(LoginDto loginUser)
        {
            try
            {
                User user = await userFetcherService.GetUserByEmail(loginUser.Email);
                PasswordVerificationResult isPasswordValid = passwordHasher.VerifyHashedPassword(user, user.UserPassword, loginUser.Password);

                if (isPasswordValid != PasswordVerificationResult.Success)
                {
                    throw new PasswordNotValidException();
                }
                WithingsTokenDto token = (await withingsProvider.RefreshToken(user.RefreshToken));
                user.RefreshToken = token.RefreshToken;
                await userRepository.Update(user);
                return new(tokenService.CreateJwtToken(user,token.AccessToken));
            }
            catch (Exception)
            {
                throw new UnauthorizedAuthenticationException(loginUser.Email);
            }

        }
    }
}
