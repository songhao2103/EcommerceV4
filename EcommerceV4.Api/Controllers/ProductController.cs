using EcommerceV4.Application.Features.Products.Commands.CloneProductExternal;
using EcommerceV4.Application.Features.Products.Queries.GetProductDetail;
using EcommerceV4.Application.Features.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/product/clone")]
        public async Task<IActionResult> CloneProductExternalAsync()
        {
            var request = new CloneProductExternalCommand();

            await _mediator.Send(request);

            return Ok("Success");
        }

        [HttpGet("/api/product")]
        public async Task<IActionResult> GetProductsAsync([FromQuery] GetProductsQuery query)
        {
            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpGet("/api/product/{productId}")]
        public async Task<IActionResult> GetProductDetail([FromRoute] int productId)
        {
            var request = new GetProductDetailQuery
            {
                ProductId = productId
            };
            var products = await _mediator.Send(request);

            return Ok(products);

        }
    }
}
