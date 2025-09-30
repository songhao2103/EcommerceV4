namespace EcommerceV4.Domain.Aggregates.UserAggregate.Interfaces
{
    public interface IUserChecker
    {
        public Task<bool> CheckUserAccount(string account);
    }
}
