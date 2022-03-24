using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BalanceApp.Infrastructure.Config
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>, IEntityTypeConfiguration<Profile>, IEntityTypeConfiguration<BodyData>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {


            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasConversion(id => id.Value, id => new UserId(id));
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.Firstname);
            builder.Property(user => user.Lastname);
            builder.Property(user => user.UserPassword);
            builder.Property(user => user.RegisterDate);
            builder.Property(user => user.Role);
            builder.HasMany(typeof(Profile), "Profiles");
            builder.ToTable("users");


        }

        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            var birthDateConverter = new ValueConverter<BirthDate, string>(b => b.ToString(),
            b => BirthDate.Create(b));

            builder.Property(p => p.Id);
            builder.Property(p => p.Firstname);
            builder.Property(p => p.Height);
            builder.Property(p => p.Lastname);
            builder.Property(p => p.Gender);
            builder.Property(typeof(BirthDate), "birthdate").HasConversion(birthDateConverter);
            builder
                .Property(p => p.BirthDate)
                .HasConversion(b => b.ToString(), b => BirthDate.Create(b));
            builder.HasMany(typeof(BodyData), "BodyDatas");
            builder.ToTable("profiles");
        }

        public void Configure(EntityTypeBuilder<BodyData> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(bd => bd.Weight);
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
