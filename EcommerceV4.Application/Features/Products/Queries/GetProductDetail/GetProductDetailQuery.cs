using EcommerceV4.Application.Features.Products.Queries.NewFolder;
using MediatR;

namespace EcommerceV4.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<GetProductDetailResponseDto>
    {
        public int ProductId { get; set; }
    }
}
