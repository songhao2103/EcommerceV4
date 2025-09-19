namespace EcommerceV4.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
