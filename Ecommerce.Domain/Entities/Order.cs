using EcommerceV4.Domain.Enums;

namespace EcommerceV4.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string AddressDetail { get; set; } =  string.Empty;
        public int City { get; set; }
        public int District { get; set; }
        public int Commune { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Created;
        public bool Paid { get; set; }
        public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    }
}
