using EcommerceV4.Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Infrastructure.Persistence.Configurations
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable(nameof(OrderDetail));

            builder.OwnsOne(od => od.Money, a =>
            {
                a.Property(p => p.Price).HasColumnName("price");
                a.Property(p => p.Discount).HasColumnName("discount");
            });

            builder.OwnsOne(od => od.ProductInfo, a =>
            {
                a.Property(p => p.ProductName).HasColumnName("name");
                a.Property(p => p.UrlImageDefault).HasColumnName("url_image_default");
                a.Property(p => p.Description).HasColumnName("description");
            });

            builder.HasKey(x => x.Id);

            builder.Property(od => od.Quantity).IsRequired();

            builder.Property(od => od.Money.Price).IsRequired().HasColumnType("decimal(18,2)");
            
            builder.Property(od => od.ProductInfo.ProductName).IsRequired();

            //OnDelete(DeleteBehavior.Cascade): Kho xóa order thì sẽ xóa luôn hết các order liên quan
            builder.HasOne(od => od.Order).WithMany(o => o.Details).HasForeignKey(od => od.OrderId).OnDelete(DeleteBehavior.Cascade);

            // OnDelete(DeleteBehavior).Restrict: Khi cố gắng xóa ProductVariant mà đang có OrderDetail tham chiếu đến nó thì DB sẽ chặn không cho xóa
            builder.HasOne(od => od.ProductVariant).WithMany().HasForeignKey(od => od.ProductVariantId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
