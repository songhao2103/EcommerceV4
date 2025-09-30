using EcommerceV4.Domain.Aggregates.RefetchTokenAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceV4.Infrastructure.Persistence.Configurations
{
    public class RefetchTokenConfiguration : IEntityTypeConfiguration<RefetchToken>
    {
        public void Configure(EntityTypeBuilder<RefetchToken> builder)
        {
            builder.ToTable(nameof(RefetchToken));

            builder.HasKey(t => t.Id);
        }
    }
}
