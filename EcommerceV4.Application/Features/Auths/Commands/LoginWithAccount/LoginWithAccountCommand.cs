using EcommerceV4.Application.Common.Abstractions.Responses;
using EcommerceV4.Application.DTOs;
using MediatR;

namespace EcommerceV4.Application.Features.Auths.Commands.LoginWithAccount
{
    public class LoginWithAccountCommand : IRequest<ApiResponseHasData<ResponseLoginDto>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
