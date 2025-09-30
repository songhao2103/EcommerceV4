using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Domain.Aggregates.ProductAggregate.Interfaces;
using EcommerceV4.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV4.Infrastructure.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IRepository<ProductVariant> _productVariantRepository;

        public ProductDomainService(IRepository<ProductVariant> productVariantRepository)
        {
            _productVariantRepository = productVariantRepository;
        }

        public async Task<Dictionary<int, int>> GetQuantityProductVariantInStock(List<int> productVariantIds)
        {
            var proVar = await _productVariantRepository.Query(pv => productVariantIds.Contains(pv.Id))
                                              .ToDictionaryAsync(pv => pv.Id, pv => pv.TotalQuantity ?? 0);

            if (proVar.Count() == 0)
            {
                throw new KeyNotFoundException("Không tìm thấy sản phẩm");
            }

            return proVar;
        }
    }
}
