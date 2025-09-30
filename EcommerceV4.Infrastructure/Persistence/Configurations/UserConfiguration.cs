using EcommerceV4.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceV4.Infrastructure.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.OwnsOne(u => u.Email, e =>
            {
                e.Property(x => x.Value)
                    .HasColumnName("email")
                    .IsRequired();
                e.Ignore("UserId");
            });

            builder.OwnsOne(u => u.Address, a =>
            {
                a.Property(p => p.AddressDetail).HasColumnName("addressDetail");
                a.Property(p => p.District).HasColumnName("district");
                a.Property(p => p.City).HasColumnName("city");
                a.Property(p => p.Commune).HasColumnName("commune");
            });

            builder.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);
        }
    }
}
