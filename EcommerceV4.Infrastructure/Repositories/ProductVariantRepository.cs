using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Infrastructure.Persistence;

namespace EcommerceV4.Infrastructure.Repositories
{
    public class ProductVariantRepository : BaseRepository<ProductVariant>
    {
        public ProductVariantRepository(EcommerceDbContext context) : base(context) { }
    }
}
