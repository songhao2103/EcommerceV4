using EcommerceV4.Domain.Aggregates.ProductAggregate.Enums;
using MediatR;

namespace EcommerceV4.Application.Features.Products.Queries.NewFolder
{
    public class GetProductDetailResponseDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public double? Discount { get; set; }
        public int QuantityInStock { get; set; }
        public int QuantitySold { get; set; }
        public DeviceType DeviceType { get; set; }
        public string? CompanyName { get; set; }
        public string? StoreName { get; set; }
        public List<string> Images { get; set; } = new List<string>();
    }
}
