
using EcommerceV4.Domain.Aggregates.CartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceV4.Infrastructure.Persistence.Configurations
{
    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable(nameof(Cart));

            builder.HasKey(x => x.Id);

            builder.HasMany(c => c.CartDetails).WithOne(cd => cd.Cart).HasForeignKey(cd => cd.CartId);
        }
    }
}
