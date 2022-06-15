using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BalanceApp.Infrastructure.Config
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var birthDateConverter = new ValueConverter<BirthDate, string>(b => b.ToString(),
            b => BirthDate.Create(b));

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasConversion(id => id.Value, id => new EntityId(id));
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.Height);
            builder.Property(user => user.Firstname);
            builder.Property(user => user.Lastname);
            builder.Property(user => user.UserPassword);
            builder.Property(user => user.RegisterDate);
            builder.Property(user => user.LastUpdate);
            builder.Property(user => user.Role);
            builder.Property(user => user.RefreshToken);
            builder
                .Property(p => p.BirthDate)
                .HasConversion(birthDateConverter);

            builder.OwnsMany(p => p.BodyDataList, p =>
            {
                p.Property(bd => bd.Weight);
                p.Property(bd => bd.FatMassRate);
                p.Property(bd => bd.WaterRate);
                p.Property(bd => bd.MuscleRate);
                p.Property(bd => bd.BoneRate);
                p.Property(bd => bd.BodyMassIndex);
                p.Property(bd => bd.CreatedAt);
            });
            builder.ToTable("users");
        }
    }
}
