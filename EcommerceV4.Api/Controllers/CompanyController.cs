using EcommerceV4.Api.DTOs.Companies;
using EcommerceV4.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IValidator<PayloadCreateCompanyDTO> _payloadCreateCompanyValidator;

        public CompanyController(ICompanyService companyService, IValidator<PayloadCreateCompanyDTO> payloadCreateCompanyValidator)
        {
            _companyService = companyService;
            _payloadCreateCompanyValidator = payloadCreateCompanyValidator;
        }

        [HttpPost("/api/company")]
        public async Task<IActionResult> CreateCompanyAsync(PayloadCreateCompanyDTO payloadCreateCompanyDTO)
        {
            var resultValidator = _payloadCreateCompanyValidator.Validate(payloadCreateCompanyDTO);

            if (!resultValidator.IsValid)
            {
                return BadRequest(resultValidator.Errors);
            } 
                
            var command = payloadCreateCompanyDTO.ToCommand();

            await _companyService.CreateCompanyAsync(command);

            return Ok("Success");
        }
    }
}
