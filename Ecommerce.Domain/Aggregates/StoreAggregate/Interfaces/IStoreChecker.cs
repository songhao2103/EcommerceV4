namespace EcommerceV4.Domain.Aggregates.StoreAggregate.Interfaces
{
    public interface IStoreChecker
    {
        public Task<bool> IsNameCheckerAsync(string name);
    }
}
