using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceV4.Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company));

            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.Address, a =>
            {
                a.Property(p => p.AddressDetail).HasColumnName("addressDetail");
                a.Property(p => p.District).HasColumnName("district");
                a.Property(p => p.City).HasColumnName("city");
                a.Property(p => p.Commune).HasColumnName("commune");
            });

            builder.Property(c => c.CompanyName).IsRequired();

            builder.HasMany(c => c.Products).WithOne(p => p.Company).HasForeignKey(p => p.CompanyId);
        }
    }
}
