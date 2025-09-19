using EcommerceV4.Application.Commands;

namespace EcommerceV4.Api.DTOs.Companies
{
    public class PayloadCreateCompanyDTO
    {
        public string CompanyName { get; set; }  =string.Empty;
        public string? Description { get; set; }
        public string? AddressDetail { get; set; }

        public CompanyCommand ToCommand()
        {
            return new CompanyCommand(CompanyName, Description, AddressDetail);
        }
    }
}
