using EcommerceV4.Domain.Aggregates.UserAggregate;

namespace EcommerceV4.Domain.Aggregates.CartAggregate
{
    internal class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<CartDetail>? CartDetails { get; set; }
    }
}
