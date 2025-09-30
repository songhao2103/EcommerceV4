using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV4.Application.Features.Stories.Queries.GetStores
{
    public class GetStoresHandler : IRequestHandler<GetStoresQuery, List<GetStoreResponseDto>>
    {
        private readonly IRepository<Store> _storeRepository;

        public GetStoresHandler(IRepository<Store> storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<List<GetStoreResponseDto>> Handle(GetStoresQuery query, CancellationToken cancellationToken)
        {
            var queryable = _storeRepository.Query(s => string.IsNullOrEmpty(query.SearchKey) || s.StoreName.ToLower().Contains(query.SearchKey));

            var stores = await queryable.Skip((query.PageIndex - 1) * query.PageSize)
                                    .Take(query.PageSize)
                                    .Select(s => new GetStoreResponseDto
                                    {
                                        Id = s.Id,
                                        StoreName = s.StoreName,
                                    }).ToListAsync(cancellationToken);

            return stores;
        }
    }
}
