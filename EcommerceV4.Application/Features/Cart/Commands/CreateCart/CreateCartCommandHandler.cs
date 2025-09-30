using EcommerceV4.Application.Common.Abstractions.Responses;
using EcommerceV4.Domain.Aggregates.CartAggregate;
using EcommerceV4.Domain.Aggregates.ProductAggregate.Interfaces;
using EcommerceV4.Domain.Repositories;
using MediatR;

namespace EcommerceV4.Application.Features.Carts.Commands.CreateCart
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, ApiResponse>
    {
        public static IUnitOfWork _unitOfWork;
        public static IRepository<Cart> _cartRepository;
        public static IProductDomainService _productDomainService;

        public CreateCartCommandHandler(IUnitOfWork unitOfWork, IRepository<Cart> cartRepository, IProductDomainService productDomainService)
        {
            _unitOfWork = unitOfWork;
            _cartRepository = cartRepository;
            _productDomainService = productDomainService;
        }

        public async Task<ApiResponse> Handle(CreateCartCommand command, CancellationToken cancellationToken)
        {
            var validCart = await _cartRepository.GetOneAsync(c => c.UserId == command.UserId);

            Cart cart;
            if (validCart == null)
            {
                cart = Cart.Create(command.UserId);
            }
            else
            {
                cart = validCart;
            }    

            var productVariantIds = command.CartDetails.Select(cd => cd.ProductVariantId).ToList();
            var stockDictionary = await _productDomainService.GetQuantityProductVariantInStock(productVariantIds);

            foreach (var cartDetail in command.CartDetails)
            {
                if(stockDictionary.TryGetValue(cartDetail.ProductVariantId, out var stock))
                {
                    cart.AddCartDetail(cartDetail.ProductVariantId, cartDetail.Quantity, stock);
                }
            }

            if(validCart == null)
            {
                _cartRepository.Add(cart);
            }
            else
            {
                _cartRepository.Update(cart);
            }


                _unitOfWork.SaveChanges();

            return ApiResponse.Ok("Tạo mới giỏ hàng thành công!");
        }
    }
}
