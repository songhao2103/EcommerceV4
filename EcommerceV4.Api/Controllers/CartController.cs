using EcommerceV4.Api.Extensions;
using EcommerceV4.Application.Common.Extenstions;
using EcommerceV4.Application.Features.Carts.Commands.CreateCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/cart")]
        [Authorize]
        public async Task<IActionResult> CreateCartAsync([FromBody] List<CreateCartDetailCommand> cartDetails)
        {
            var userId = User.GetUserIdHasActionResult();

            var command = new CreateCartCommand
            {
                UserId = userId,
                CartDetails = cartDetails,
            };

            var result = await _mediator.Send(command);

            return result.ToActionResult();
        }
        
    }
}
