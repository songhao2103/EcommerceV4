using EcommerceV4.Domain.Aggregates.ProductAggregate;

namespace EcommerceV4.Domain.Aggregates.CartAggregate
{
    public class CartDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }

        public CartDetail(int quantity, int productVariantId)
        {
            this.Quantity = quantity;
            this.ProductVariantId = productVariantId;
        }

        public static CartDetail Create(int quantity, int productVariantId)
        {
            return new CartDetail(quantity, productVariantId);
        }

        public void UpdateQuantity(int quantity, int stock)
        {
            if(quantity < 0)
            {
                throw new ArgumentException("Số lượng phải lớn hơn 0!");
            }
            else if(quantity > stock)
            {
                throw new FormatException("Số lượng trong kho không đủ!");
            }    
            else
            {
                Quantity = quantity;
            } 
        }
    }
}
