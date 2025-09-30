using EcommerceV4.Domain.Aggregates.UserAggregate;
using EcommerceV4.Infrastructure.Persistence;

namespace EcommerceV4.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(EcommerceDbContext context) : base(context) { }  
    }
}
