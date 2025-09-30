using EcommerceV4.Application.Common.Abstractions.Responses;
using EcommerceV4.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Application.Features.Auths.Commands.LoginWithGoogle
{
    public class LoginWithGoogleCommand : IRequest<ApiResponseHasData<ResponseLoginDto>>
    {
        public string Credential { get; set; } = string.Empty;
    }
}
