namespace EcommerceV4.Domain.Aggregates.ProductAggregate
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public int TotalQuantity { get; set; }
        public int QuantityInStock { get; set; }
        public string ColorCode { get; set; } = string.Empty;
        public string ColorName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
