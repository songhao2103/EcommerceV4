using EcommerceV4.Application.Common.Abstractions.Responses;
using MediatR;

namespace EcommerceV4.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<ApiResponseHasData<int>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public string? AddressDetail { get; set; }
        public string? RePassword { get; set; }
        public int? City { get; set; }
        public int? District { get; set; }
        public int? Commune { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
