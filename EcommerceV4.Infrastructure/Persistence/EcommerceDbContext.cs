using Microsoft.EntityFrameworkCore;

namespace EcommerceV4.Infrastructure.Persistence
{
    internal class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }


    }
}
