using EcommerceV4.Domain.Common.Abstractions;

namespace EcommerceV4.Domain.Aggregates.ProductAggregate
{
    public class ProductVariant : BaseEntity<int>
    {
        public string ImageUrl { get; set; } = string.Empty;
        public int? TotalQuantity { get; set; }
        public int? QuantityInStock { get; set; }
        public string? ColorCode { get; set; }
        public string? ColorName { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public static ProductVariant Create
            (
                string imageUrl,
                int? totalQuantity,
                int? quantityInStock,
                string? colorCode,
                string? colorName,
                int productId
            )
        {
            if(string.IsNullOrEmpty(imageUrl))
            {
                throw new Exception("Ảnh không được để trống!");
            }

            if(totalQuantity < 0 || quantityInStock < 0)
            {
                throw new Exception("Số lượng không hợp lệ!");
            } 

            if(quantityInStock > totalQuantity)
            {
                throw new Exception("Số lượng trong kho phải nhỏ hơn tổng số lượng");
            }

            return new ProductVariant
            {
                ImageUrl = imageUrl,
                TotalQuantity = totalQuantity,
                QuantityInStock = quantityInStock,
                ColorCode = colorCode,
                ColorName = colorName,
                ProductId = productId
            };  
        }
    }
}
