using EcommerceV4.Application.DTOs;
using EcommerceV4.Domain.Aggregates.UserAggregate;

namespace EcommerceV4.Application.Common.Interfaces
{
    public interface IAuthService
    {
        public Task<ResponseLoginDto> CreateResponseLogin(User user);
    }
}
