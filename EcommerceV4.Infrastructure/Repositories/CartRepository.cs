using EcommerceV4.Domain.Aggregates.CartAggregate;
using EcommerceV4.Infrastructure.Persistence;

namespace EcommerceV4.Infrastructure.Repositories
{
    public class CartRepository : BaseRepository<Cart>
    {
        public CartRepository(EcommerceDbContext context) : base(context)
        {

        }
    }
}
