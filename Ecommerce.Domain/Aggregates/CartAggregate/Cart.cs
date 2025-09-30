using EcommerceV4.Domain.Aggregates.UserAggregate;

namespace EcommerceV4.Domain.Aggregates.CartAggregate
{
    public class Cart
    {
        private readonly List<CartDetail> _cartDetails = new();
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public IReadOnlyCollection<CartDetail> CartDetails => _cartDetails.AsReadOnly();

        public Cart(int userId)
        {
            this.UserId = userId;
        }

        public static Cart Create(int userId)
        {
            return new Cart(userId);
        }

        public void AddCartDetail(int productVariantId, int quantity, int stock)
        {
            var exitingItem = _cartDetails.Where(c => c.ProductVariantId == productVariantId).FirstOrDefault();

            if(exitingItem == null)
            {
                _cartDetails.Add(CartDetail.Create(quantity, productVariantId));
            }
            else
            {
                exitingItem.UpdateQuantity(quantity, stock);
            }
        }

        public void RemoveCartDetail(int cartDetailId)
        {
            var item =  _cartDetails.Where(c => c.Id == cartDetailId).FirstOrDefault();

            if (item == null)
            {
                throw new KeyNotFoundException("Không tìm thấy sản phẩm!");
            }

            _cartDetails.Remove(item);
        }
    }
}
