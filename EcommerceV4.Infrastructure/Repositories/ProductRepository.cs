using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Infrastructure.Persistence;

namespace EcommerceV4.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(EcommerceDbContext context) : base(context) { }
    }
}
