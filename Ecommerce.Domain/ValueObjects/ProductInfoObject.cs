namespace EcommerceV4.Domain.ValueObjects
{
    public class ProductInfoObject
    {
        public string? UrlImageDefault { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }

        public ProductInfoObject(string? urlImageDefault, string? productName, string? description)
        {
            UrlImageDefault = urlImageDefault;
            ProductName = productName;
            Description = description;
        }
    }
}
