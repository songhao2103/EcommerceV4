using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Infrastructure.Persistence;

namespace EcommerceV4.Infrastructure.Repositories
{
    public class StoreRepository : BaseRepository<Store>
    {
        public StoreRepository(EcommerceDbContext context) : base(context) { }
    }
}
