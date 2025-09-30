using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Aggregates.ProductAggregate.Enums;
using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Domain.Common.Abstractions;

namespace EcommerceV4.Domain.Aggregates.ProductAggregate
{
    public class Product : BaseEntity<int>
    {
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public double? Discount { get; set; }
        public DeviceType DeviceType { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();

        public override string ToString()
        {
            return $"{ProductName} {Description}";
        }

        public static Product Create(
            string productName,
            string? description,
            decimal price,
            double discount,
            DeviceType deviceType,
            int? companyId,
            int storeId
            )
        {
            if(string.IsNullOrEmpty(productName))
            {
                throw new Exception("Tên sản phẩm không được để trống!");
            }    

            if(price < 0)
            {
                throw new Exception("Giá sản phẩm không được nhỏ hơn không!");
            }

            if (discount > 100 || discount < 0)
            {
                throw new Exception("Discout không hợp lệ!");
            }

            return new Product
            {
                ProductName = productName,
                Description = description,
                Price = price,
                Discount = discount,
                CompanyId = companyId,
                StoreId = storeId,
                DeviceType = deviceType
            };
        }
    }
}
