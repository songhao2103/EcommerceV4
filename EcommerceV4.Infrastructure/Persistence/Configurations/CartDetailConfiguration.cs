using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceV4.Domain.Aggregates.CartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceV4.Infrastructure.Persistence.Configurations
{
    internal class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable(nameof(CartDetail));

            builder.HasKey(x => x.Id);

            builder.HasOne(cd => cd.Cart).WithMany(c => c.CartDetails).HasForeignKey(cd => cd.CartId);
        }
    }
}
