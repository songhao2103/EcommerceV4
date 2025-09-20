using EcommerceV4.Domain.Aggregates.ProductAggregate;

namespace EcommerceV4.Domain.Aggregates.CompanyAggregate
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? AddressDetail { get; set; }
        public List<Product> Products { get; set; } = new();


        public Company() { }
        public Company(string companyName, string? description, string? addressDetail)
        {
            CompanyName = companyName;
            Description = description;
            AddressDetail = addressDetail;
        }
    }
}
