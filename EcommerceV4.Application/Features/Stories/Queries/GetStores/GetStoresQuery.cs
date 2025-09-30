using EcommerceV4.Application.Common;
using MediatR;

namespace EcommerceV4.Application.Features.Stories.Queries.GetStores
{
    public class GetStoresQuery : BaseQuery, IRequest<List<GetStoreResponseDto>>
    {
        
    }
}
