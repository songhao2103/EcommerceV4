using EcommerceV4.Application.Features.Stories.Commands.CreateStore;
using EcommerceV4.Application.Features.Stories.Queries.GetStores;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateStoreCommand> _createCommandValidator;

        public StoreController(IMediator mediator, IValidator<CreateStoreCommand> createCommandValidator)
        {
            _mediator = mediator;
            _createCommandValidator = createCommandValidator;
        }

        [HttpPost("/api/store")]
        public async Task<IActionResult> CreateStoreAsync(CreateStoreCommand command)
        {
            var valid = _createCommandValidator.Validate(command);

            if (!valid.IsValid)
            {
                return BadRequest(valid.Errors);
            }

            var result = await _mediator.Send(command);

            return Ok($"Success {result}");
        }

        [HttpGet("/api/store")]
        public async Task<IActionResult> GetStoresAsync([FromQuery] GetStoresQuery query)
        {
            var stores =  await _mediator.Send(query);
            return Ok(stores);
        }
    }
}
