using Microsoft.EntityFrameworkCore;
using EcommerceV4.Domain.Aggregates.OrderAggregate;
using EcommerceV4.Domain.Aggregates.UserAggregate;

namespace EcommerceV4.Infrastructure.Persistence
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetail { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcommerceDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
