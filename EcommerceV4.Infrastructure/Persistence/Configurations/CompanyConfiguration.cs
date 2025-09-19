using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CompanyName).IsRequired();

            builder.HasMany(c => c.Products).WithOne(p => p.Company).HasForeignKey(p => p.CompanyId);
        }
    }
}
