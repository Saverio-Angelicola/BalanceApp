using BalanceApp.API.Datas;
using BalanceApp.API.Entities;
using BalanceApp.API.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BalanceApp.API.Datas
{
    public class Context : DbContext, IContext
    {
        public DbSet<User>? Users { get; set; }

        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserEntityTypeConfiguration configuration = new UserEntityTypeConfiguration();
            modelBuilder.ApplyConfiguration<Balance>(configuration);
            modelBuilder.ApplyConfiguration<BodyData>(configuration);
            modelBuilder.ApplyConfiguration<User>(configuration);
        }
    }
}
