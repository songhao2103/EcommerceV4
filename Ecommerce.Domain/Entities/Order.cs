using EcommerceV4.Domain.Enums;
using EcommerceV4.Domain.ValueObjects;

namespace EcommerceV4.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public AddressObject? Address { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Created;
        public bool Paid { get; set; }
        public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    }
}
