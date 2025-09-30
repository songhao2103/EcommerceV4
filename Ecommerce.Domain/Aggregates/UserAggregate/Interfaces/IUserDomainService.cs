namespace EcommerceV4.Domain.Aggregates.UserAggregate.Interfaces
{
    public interface IUserDomainService
    {
        public Task<bool> ValidateUserAccount(string account);
    }
}
