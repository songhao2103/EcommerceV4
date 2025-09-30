using MediatR;

namespace EcommerceV4.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQuery : BaseQuery, IRequest<List<GetProductResponseDto>>
    {
    }
}
