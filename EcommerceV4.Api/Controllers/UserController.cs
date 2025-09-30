using EcommerceV4.Application.Features.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("/api/user")]
        public async Task<IActionResult> RegisterUserAsync(RegisterUserCommand command)
        {
            var resultHandler = await _mediator.Send(command);
            return Ok(resultHandler);
        }
    }
}
