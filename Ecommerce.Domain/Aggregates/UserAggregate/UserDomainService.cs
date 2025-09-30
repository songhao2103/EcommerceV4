using EcommerceV4.Domain.Aggregates.UserAggregate.Interfaces;

namespace EcommerceV4.Infrastructure.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserChecker _userChecker;

        public UserDomainService(IUserChecker userChecker)
        {
            _userChecker = userChecker;
        }

        public async Task<bool> ValidateUserAccount(string account)
        {
            return await _userChecker.CheckUserAccount(account);
        }
    }
}
