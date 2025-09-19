using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Aggregates.ProductAggregate.Enums;
using EcommerceV4.Domain.Aggregates.StoreAggregate;

namespace EcommerceV4.Domain.Aggregates.ProductAggregate
{
    public class Product
    {
        public int Id { get; set; }
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

    }
}
