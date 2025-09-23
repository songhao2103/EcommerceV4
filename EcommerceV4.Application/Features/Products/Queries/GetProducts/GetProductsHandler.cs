using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV4.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<GetProductResponseDto>>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Store> _storeRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<ProductVariant> _productVariantRepository;


        public GetProductsHandler(
            IRepository<Product> productRepository,
            IRepository<Store> storeRepository,
            IRepository<Company> companyRepository,
            IRepository<ProductVariant> productVariantRepository
            )
        {
            _productRepository = productRepository;
            _storeRepository = storeRepository;
            _companyRepository = companyRepository;
            _productVariantRepository = productVariantRepository;
        }

        public async Task<List<GetProductResponseDto>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var queryable = from p in _productRepository.Query(x => string.IsNullOrEmpty(query.SearchKey) || x.ProductName.ToLower().Contains(query.SearchKey))
                        join s in _storeRepository.GetAll() on p.StoreId equals s.Id
                        join c in _companyRepository.GetAll() on p.CompanyId equals c.Id
                        join pv in _productVariantRepository.GetAll() on p.Id equals pv.ProductId into pvGroup
                        from pv in pvGroup
                            .OrderByDescending(v => v.TotalQuantity - v.QuantityInStock)
                            .Take(1) // <- EF Core dịch được
                            .DefaultIfEmpty()
                        select new GetProductResponseDto
                        {
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Discount = p.Discount,
                            Description = p.Description,
                            DeviceType = p.DeviceType,
                            CompanyName = c.CompanyName,
                            StoreName = s.StoreName,
                            ImageUrl = pv.ImageUrl
                        };

            var products = await queryable
                            .OrderBy(x => x.ProductName)
                            .Skip((query.PageIndex - 1) * query.PageSize)
                            .Take(query.PageSize)
                            .ToListAsync(cancellationToken);

            
            return products;
        }
    }
}
