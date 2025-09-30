using EcommerceV4.Application.Features.Users.Commands.RegisterUser;
using EcommerceV4.Domain.Aggregates.UserAggregate;

namespace EcommerceV4.Application.Common.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUserNoSaveChange(RegisterUserCommand command);
    }
}
