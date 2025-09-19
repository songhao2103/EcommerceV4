using EcommerceV4.Api.DTOs.Companies;
using EcommerceV4.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Api.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("/api/company")]
        public async Task<IActionResult> CreateCompanyAsync(PayloadCreateCompanyDTO payloadCreateCompanyDTO)
        {
            var command = payloadCreateCompanyDTO.ToCommand();

            await _companyService.CreateCompanyAsync(command);

            return Ok("Success");
        }
    }
}
