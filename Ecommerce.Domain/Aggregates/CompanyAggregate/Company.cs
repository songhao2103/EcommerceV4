using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Domain.Common.Abstractions;
using EcommerceV4.Domain.Common.ValueObjects;

namespace EcommerceV4.Domain.Aggregates.CompanyAggregate
{
    public class Company : BaseAggregateRoot<int>
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public AddressObject? Address { get; set; }
        public List<Product> Products { get; set; } = new();

        public Company() { }

        public static Company Create(string companyName, string? description, AddressObject address)
        {
            return new Company
            {
                CompanyName = companyName,
                Description = description,
                Address = address,
            };
        }

    }
}
