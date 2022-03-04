using BalanceApp.Application.Services.implementations.Auth;
using BalanceApp.Application.Services.implementations.Users;
using BalanceApp.Application.Services.implementations.Withings;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Application.Services.interfaces.Withings;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BalanceApp.Application
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IWithingsService, WithingsService>();

            return services;
        }
    }
}
