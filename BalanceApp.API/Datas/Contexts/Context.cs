using BalanceApp.API.Datas.Config;
using BalanceApp.API.Entities;
using BalanceApp.API.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BalanceApp.API.Datas.Contexts
{
    public class Context : DbContext, IContext
    {
        public DbSet<User>? Users { get; set; }

        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserEntityTypeConfiguration configuration = new();
            modelBuilder.ApplyConfiguration<Balance>(configuration);
            modelBuilder.ApplyConfiguration<BodyData>(configuration);
            modelBuilder.ApplyConfiguration<User>(configuration);
        }
    }
}
