using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Application.Features.Products.Externals;
using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Domain.Aggregates.ProductAggregate.Enums;
using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV4.Application.Features.Products.Commands.CloneProductExternal
{
    internal class CloneProductExternalHandler : IRequestHandler<CloneProductExternalCommand>
    {
        private readonly IExternalApi<List<ProductExternal>> _externalApi;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductVariant> _productVariantRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Store> _storeRepository;

        public CloneProductExternalHandler(
            IRepository<Product> productRepository,
            IRepository<ProductVariant> productVariantRepository,
            IRepository<Store> storeRepository,
            IRepository<Company> companyRepository,
            IUnitOfWork unitOfWork,
            IExternalApi<List<ProductExternal>> externalApi
            )
        {
            _unitOfWork = unitOfWork;
            _externalApi = externalApi;
            _productVariantRepository = productVariantRepository;
            _productRepository = productRepository;
            _companyRepository = companyRepository;
            _storeRepository = storeRepository;
        }

        public async Task Handle(CloneProductExternalCommand request, CancellationToken cancellationToken)
        {
            var products = await _externalApi.GetData();

            var companyDict = await _companyRepository.GetAll().
                ToDictionaryAsync(c => c.CompanyName.ToLower(), c => c.Id);

            var storeDict = await _storeRepository.GetAll()
                .ToDictionaryAsync(s => s.StoreName.ToLower(), s => s.Id);


            var colorMap = new Dictionary<string, (string Code, string Name, Func<ProductExternal, int?> Quantity)>
                            {
                                { "black", ("#000", "Black", p => p.BlackQuantity) },
                                { "white", ("#fff", "White", p => p.WhiteQuantity) },
                                { "pink",  ("#ff70f6", "Pink", p => p.PinkQuantity) }
                            };

            foreach (var product in products)
            {
                companyDict.TryGetValue(product.Company.ToLower(), out var companyId);
                storeDict.TryGetValue(product.StoreName.ToLower(), out var storeId);

                if (!Enum.TryParse<DeviceType>(product.DeviceType, true, out var deviceType))
                {
                    deviceType = DeviceType.Other;
                }

                var productDb = new Product
                {
                    ProductName = product.ProductName,
                    Description = product.Describe,
                    Price = (decimal)product.Price,
                    Discount = product.Discount,
                    CompanyId = companyId,
                    StoreId = storeId,
                    DeviceType = deviceType
                };

                _productRepository.Add(productDb);

                // Tạo list variant (QuantityImageOfProduct)
                foreach (var image in product.Images)
                {
                    if(image.Color == null)
                    {
                        var variant = new ProductVariant
                        {
                            ColorCode = null,
                            ColorName = null,
                            TotalQuantity = null,
                            QuantityInStock = null,
                            ImageUrl = image.Url ?? "",
                            Product = productDb
                        };

                        _productVariantRepository.Add(variant);
                    }    
                    else if (colorMap.TryGetValue(image.Color.ToLower(), out var colorInfo))
                    {
                        var defaultQuantity = colorInfo.Quantity(product) ?? 0;

                        var variant = new ProductVariant
                        {
                            ColorCode = colorInfo.Code,
                            ColorName = colorInfo.Name,
                            TotalQuantity = defaultQuantity,
                            QuantityInStock = defaultQuantity,
                            ImageUrl = image.Url ?? "",
                            Product = productDb 
                        };

                       _productVariantRepository.Add(variant);
                    }
                }
            }

            // Chỉ SaveChanges 1 lần
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
