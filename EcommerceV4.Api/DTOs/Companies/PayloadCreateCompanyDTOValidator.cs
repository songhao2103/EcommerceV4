using FluentValidation;

namespace EcommerceV4.Api.DTOs.Companies
{
    public class PayloadCreateCompanyDTOValidator : AbstractValidator<PayloadCreateCompanyDTO>
    {
        public PayloadCreateCompanyDTOValidator() 
        {
            RuleFor(c => c.CompanyName).NotEmpty();
        } 
    }
}
