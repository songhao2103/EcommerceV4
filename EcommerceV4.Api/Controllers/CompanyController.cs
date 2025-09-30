using EcommerceV4.Application.Common.Extenstions;
using EcommerceV4.Application.Features.Companies.Commands.CreateCompany;
using EcommerceV4.Application.Features.Companies.Queries.GetCompanies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/company")]
        //[Authorize]
        public async Task<IActionResult> CreateCompanyAsync(CreateCompanyCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpGet("/api/company")]
        public async Task<IActionResult> GetCompaniesAsync([FromQuery] GetCompaniesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
