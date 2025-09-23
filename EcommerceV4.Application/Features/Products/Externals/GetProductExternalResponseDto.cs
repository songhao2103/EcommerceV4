namespace EcommerceV4.Application.Features.Products.Externals
{
    public class ImageOfProductOnMongoDTO
    {
        public string Color { get; set; }
        public string Url { get; set; }
        public string ProductId { get; set; }
    }

    public class ProductExternal
    {
        public string ProductName { get; set; }
        public string Describe { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Company { get; set; }
        public string DeviceType { get; set; }
        public List<ImageOfProductOnMongoDTO> Images { get; set; }
        public int TotalQuantity { get; set; }
        public int? BlackQuantity { get; set; }
        public int? WhiteQuantity { get; set; }
        public int? PinkQuantity { get; set; }
        public int QuantityOrdered { get; set; }
        public double Rating { get; set; }
        public int NumberOfReview { get; set; }
        public string Status { get; set; }
        public string StoreName { get; set; }
        public string ReasonForRefusal { get; set; }
        public int? QuantitySold { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class GetProductExternalResponseDto
    {
        public List<ProductExternal> products { get; set; }
    }
}
