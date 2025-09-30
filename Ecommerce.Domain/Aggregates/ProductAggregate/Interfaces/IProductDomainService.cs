namespace EcommerceV4.Domain.Aggregates.ProductAggregate.Interfaces
{
    public interface IProductDomainService
    {
        public Task<Dictionary<int, int>> GetQuantityProductVariantInStock(List<int> productVariantId);
    }
}
