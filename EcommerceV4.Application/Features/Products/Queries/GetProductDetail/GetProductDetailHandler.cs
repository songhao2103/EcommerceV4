using EcommerceV4.Application.Features.Products.Queries.NewFolder;
using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV4.Application.Features.Products.Queries.GetProductDetail
{
    internal class GetProductDetailHandler : IRequestHandler<GetProductDetailQuery, GetProductDetailResponseDto>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductVariant> _productVariantRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Store> _storeRepository;

        public GetProductDetailHandler
            (
                IRepository<Product> productRepository,
                IRepository<ProductVariant> productVariantRepository,
                IRepository<Store> storeRepository,
                IRepository<Company> companyRepository
            )
        {
            _productRepository = productRepository;
            _productVariantRepository = productVariantRepository;
            _storeRepository = storeRepository;
            _companyRepository = companyRepository;
        }


        public async Task<GetProductDetailResponseDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var queryable = from p in _productRepository.GetAll()
                            join s in _storeRepository.GetAll() on p.StoreId equals s.Id
                            join c in _companyRepository.GetAll() on p.CompanyId equals c.Id
                            join pv in (
                                            from pv in _productVariantRepository.GetAll()
                                            group pv by pv.ProductId into pvGroup

                                            select new
                                            {
                                                productId = pvGroup.Key,
                                                quantityInStock = pvGroup.Sum(y => y.QuantityInStock) ?? 0,
                                                quantitySold = pvGroup.Sum(y => y.TotalQuantity - y.QuantityInStock) ?? 0,
                                                imageUrls = pvGroup.Select(y => y.ImageUrl)
                                            }
                                         )
                            on p.Id equals pv.productId

                            select new
                            {
                                Product = p,
                                Store = s,
                                Company = c,
                                pv.quantityInStock,
                                pv.quantitySold,
                                ImageUrls = pv.imageUrls // EF vẫn chưa translate ToList()
                            };

            var result = await queryable.ToListAsync();

            var products = result.Select(x => new GetProductDetailResponseDto
            {
                ProductName = x.Product.ProductName,
                Price = x.Product.Price,
                Discount = x.Product.Discount,
                Description = x.Product.Description,
                DeviceType = x.Product.DeviceType,
                QuantityInStock = x.quantityInStock,
                QuantitySold = x.quantitySold,
                Images = x.ImageUrls.ToList(), // chuyển sang list ở memory
                CompanyName = x.Company.CompanyName,
                StoreName = x.Store.StoreName,
            }).FirstOrDefault();


            return products;
        }
    }
}
