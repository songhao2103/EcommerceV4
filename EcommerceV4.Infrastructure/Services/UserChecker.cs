using EcommerceV4.Domain.Aggregates.UserAggregate;
using EcommerceV4.Domain.Aggregates.UserAggregate.Interfaces;
using EcommerceV4.Domain.Repositories;

namespace EcommerceV4.Infrastructure.Services
{
    public class UserChecker : IUserChecker
    {
        private readonly IRepository<User> _userRepository;

        public UserChecker(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CheckUserAccount(string account)
        {
            var exists = await _userRepository.AnyAsync(u => account == u.Email.Value);

            return !exists;
        }
    }
}
