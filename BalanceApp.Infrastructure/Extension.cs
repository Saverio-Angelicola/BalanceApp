using BalanceApp.Application.Providers;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.Providers;
using BalanceApp.Infrastructure.Datas;
using BalanceApp.Infrastructure.Http;
using BalanceApp.Infrastructure.Providers;
using BalanceApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BalanceApp.Infrastructure
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (!string.IsNullOrEmpty(connectionUrl))
            {
                var databaseUri = new Uri(connectionUrl);

                string db = databaseUri.LocalPath.TrimStart('/');
                string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string connectionString = $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;"; //configuration.GetConnectionString("defaultConnection"); 
                services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));
            }
            else
            {
                string connectionString = configuration.GetConnectionString("defaultConnection");
                services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));
            }


            services.AddScoped<IContext, Context>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IWithingsProvider, WithingsProvider>();
            services.AddScoped<IHttpClient, Client>();
            return services;
        }
    }
}
