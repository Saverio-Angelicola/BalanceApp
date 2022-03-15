using BalanceApp.Application.Services.implementations.Auth;
using BalanceApp.Application.Services.implementations.Profiles;
using BalanceApp.Application.Services.implementations.Users;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Profiles;
using BalanceApp.Application.Services.interfaces.Users;
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
            services.AddScoped<IUserUpdaterService, UserUpdaterService>();
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();
            services.AddScoped<IUserFetcherService, UserFetcherService>();
            services.AddScoped<IUserDeletionService, UserDeletionService>();
            services.AddScoped<IProfileUpdaterService, ProfileUpdaterService>();
            services.AddScoped<IProfileFetcherService, ProfileFetcherService>();
            services.AddScoped<IProfileCreatorService, ProfileCreatorService>();
            services.AddScoped<IProfileDeletionService, ProfileDeletionService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
