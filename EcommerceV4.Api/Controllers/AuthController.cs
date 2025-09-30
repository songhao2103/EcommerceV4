using EcommerceV4.Application.Common.Extenstions;
using EcommerceV4.Application.Features.Auths.Commands.LoginWithAccount;
using EcommerceV4.Application.Features.Auths.Commands.LoginWithGoogle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) 
        {
           _mediator = mediator;
        }

        [HttpGet("/api/auth/login/google")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithGoogleAsync([FromQuery] LoginWithGoogleCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPost("/api/auth/login")]
        public async Task<IActionResult> LoginWithAccountAsync([FromBody] LoginWithAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }
    }
}
