
using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Domain.Common.Abstractions;
using EcommerceV4.Domain.Common.ValueObjects;

namespace EcommerceV4.Domain.Aggregates.StoreAggregate
{
    public class Store : BaseAggregateRoot<int>
    {
        public string StoreName { get; private set; } = string.Empty;
        public string? Avatar { get; private set; }
        public AddressObject? Address { get; private set; }
        public List<Product> Products { get; private set; } = new();

        public Store() { }

        public static Store Create(string storeName, string? avatar, AddressObject? address)
        {
            return new Store
            {
                StoreName = storeName,
                Avatar = avatar,
                Address = address
            };
        }
    }
}
