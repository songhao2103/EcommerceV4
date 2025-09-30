namespace EcommerceV4.Domain.Aggregates.StoreAggregate.Interfaces
{
    public interface IStoreDomainService
    {
        public Task ValidateStoreNameAsync(string name);
    }
}
