using EcommerceV4.Application.Common.Extenstions;
using EcommerceV4.Application.Features.Stories.Commands.CreateStore;
using EcommerceV4.Application.Features.Stories.Queries.GetStores;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/store")]
        public async Task<IActionResult> CreateStoreAsync(CreateStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpGet("/api/store")]
        public async Task<IActionResult> GetStoresAsync([FromQuery] GetStoresQuery query)
        {
            var stores =  await _mediator.Send(query);
            return Ok(stores);
        }
    }
}
