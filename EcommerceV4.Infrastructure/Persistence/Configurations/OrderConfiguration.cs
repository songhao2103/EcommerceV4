using EcommerceV4.Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceV4.Infrastructure.Persistence.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(o => o.Id);
            
            builder.Property(o => o.UserId).IsRequired();

            builder.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);

            builder.OwnsOne(o => o.Address, a =>
            {
                a.Property(p => p.AddressDetail).HasColumnName("address_detail");
                a.Property(p => p.City).HasColumnName("city");
                a.Property(p => p.District).HasColumnName("district");
                a.Property(p => p.Commune).HasColumnName("commune");
            });
            
            builder.HasMany(o => o.Details).WithOne(od => od.Order).HasForeignKey(od => od.OrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
