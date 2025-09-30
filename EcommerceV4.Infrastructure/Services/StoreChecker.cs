using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Domain.Aggregates.StoreAggregate.Interfaces;
using EcommerceV4.Domain.Repositories;

namespace EcommerceV4.Infrastructure.Services
{
    public class StoreChecker : IStoreChecker
    {
        private readonly IRepository<Store> _storeRepository;

        public StoreChecker(IRepository<Store> storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<bool> IsNameCheckerAsync(string name)
        {
            return await _storeRepository.AnyAsync(s => s.StoreName == name);
        }
    }
}
