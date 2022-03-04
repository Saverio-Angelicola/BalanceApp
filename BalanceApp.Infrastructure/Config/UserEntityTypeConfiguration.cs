using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BalanceApp.Infrastructure.Config
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>, IEntityTypeConfiguration<Balance>, IEntityTypeConfiguration<BodyData>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasConversion(id => id.Value, id => new UserId(id));
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.FirstName);
            builder.Property(user => user.LastName);
            builder.Property(user => user.Email);
            builder.Property(user => user.UserPassword);
            builder.Property(user => user.RegisterDate);
            builder.HasMany(typeof(Balance), "Balances");
            builder.HasMany(typeof(BodyData), "BodyDatas");
            builder.ToTable("Users");


        }

        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(b => b.Name);
            builder.Property(b => b.MacAddress);
            builder.ToTable("balances");
        }

        public void Configure(EntityTypeBuilder<BodyData> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(bd => bd.Weight);
            builder.Property(bd => bd.Height);
            builder.Property(bd => bd.FatMassRate);
            builder.Property(bd => bd.WaterRate);
            builder.Property(bd => bd.MuscleRate);
            builder.Property(bd => bd.BoneRate);
            builder.Property(bd => bd.HeartBeat);
            builder.Property(bd => bd.BodyMassIndex);
            builder.Property(bd => bd.CreatedAt);
            builder.ToTable("bodyDatas");
        }
    }
}
