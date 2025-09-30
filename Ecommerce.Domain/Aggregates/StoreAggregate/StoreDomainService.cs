using EcommerceV4.Domain.Aggregates.StoreAggregate.Interfaces;

namespace EcommerceV4.Domain.Aggregates.StoreAggregate
{
    public class StoreDomainService : IStoreDomainService
    {
        private readonly IStoreChecker _storeChecker;

        public StoreDomainService(IStoreChecker storeChecker)
        {
            _storeChecker = storeChecker;
        }

        public async Task ValidateStoreNameAsync(string name)
        {
            if(await _storeChecker.IsNameCheckerAsync(name))
            {
                throw new Exception("Duplicate store name!");
            }    
        }
    }
}
