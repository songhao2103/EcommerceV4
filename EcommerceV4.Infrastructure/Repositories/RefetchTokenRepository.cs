using EcommerceV4.Domain.Aggregates.RefetchTokenAggregate;
using EcommerceV4.Infrastructure.Persistence;

namespace EcommerceV4.Infrastructure.Repositories
{
    public class RefetchTokenRepository : BaseRepository<RefetchToken>
    {
        public RefetchTokenRepository(EcommerceDbContext context) : base(context) { }
    }
}
