using EcommerceV4.Domain.Aggregates.ProductAggregate.Enums;

namespace EcommerceV4.Application.Features.Products.Queries.GetProducts
{
    public class GetProductResponseDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public double? Discount { get; set; }
        public DeviceType DeviceType { get; set; }
        public string? CompanyName { get; set; }
        public string? StoreName { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
