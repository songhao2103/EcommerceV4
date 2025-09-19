using EcommerceV4.Domain.Entities;
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
            
            builder.HasMany(o => o.Details).WithOne(od => od.Order).HasForeignKey(od => od.OrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
