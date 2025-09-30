namespace EcommerceV4.Application.Features.Carts.Commands.CreateCart
{
    public class CreateCartDetailCommand
    {
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; }
    }
}
