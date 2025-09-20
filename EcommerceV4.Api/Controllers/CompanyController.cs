using EcommerceV4.Application.Features.Companies.Commands.CreateCompany;
using EcommerceV4.Application.Features.Companies.Queries.GetCompanies;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateCompanyCommand> _createCommandValidator;

        public CompanyController(IMediator mediator, IValidator<CreateCompanyCommand> createCommandValidator)
        {
            _mediator = mediator;
            _createCommandValidator = createCommandValidator;
        }

        [HttpPost("/api/company")]
        public async Task<IActionResult> CreateCompanyAsync(CreateCompanyCommand command)
        {
            var resultValidator = _createCommandValidator.Validate(command);

            if (!resultValidator.IsValid)
            {
                return BadRequest(resultValidator.Errors);
            } 
               

            int companyId = await _mediator.Send(command);

            return Ok("Success");
        }

        [HttpGet("/api/company")]
        public async Task<IActionResult> GetCompaniesAsync(GetCompaniesQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
