namespace EcommerceV4.Domain.Aggregates.CartAggregate.Interfaces
{
    public interface ICartDomainService 
    {
        public Task<int> GetQuantityDetailInStock(int productVariantId);
    }
}
