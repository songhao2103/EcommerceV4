
using EcommerceV4.Domain.Aggregates.StoreAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceV4.Infrastructure.Persistence.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable(nameof(Store));

            builder.HasKey(x => x.Id);

            builder.Property(s => s.StoreName).IsRequired();

            builder.OwnsOne(s => s.Address, a =>
            {
                a.Property(p => p.AddressDetail).HasColumnName("addressDetail");
                a.Property(p => p.District).HasColumnName("district");
                a.Property(p => p.City).HasColumnName("city");
                a.Property(p => p.Commune).HasColumnName("commune");
            });

            builder.HasMany(s => s.Products).WithOne(p => p.Store).HasForeignKey(p => p.StoreId);
        }
    }
}
