using EcommerceV4.Domain.Aggregates.OrderAggregate;

namespace EcommerceV4.Domain.Aggregates.UserAggregate
{
    public class User
    {
        public int Id { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
