using EcommerceV4.Domain.Aggregates.ProductAggregate;

namespace EcommerceV4.Domain.Aggregates.CartAggregate
{
    internal class CartDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}
