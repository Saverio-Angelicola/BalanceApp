using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;
using BalanceApp.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace BalanceApp.Infrastructure.Datas
{
    public class Context : DbContext, IContext
    {
        public DbSet<User>? Users { get; set; }

        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserEntityTypeConfiguration configuration = new();
            modelBuilder.ApplyConfiguration<BodyData>(configuration);
            modelBuilder.ApplyConfiguration<User>(configuration);
        }
    }
}
