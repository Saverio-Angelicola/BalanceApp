using BalanceApp.API.Datas;
using BalanceApp.Application.Datas;
using BalanceApp.Application.Repositories;
using BalanceApp.Infrastructure.Datas.Contexts;
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
            string connectionString = configuration.GetConnectionString("defaultConnection");
            services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IContext, Context>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
