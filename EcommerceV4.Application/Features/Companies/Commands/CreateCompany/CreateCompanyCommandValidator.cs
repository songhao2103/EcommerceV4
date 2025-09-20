using FluentValidation;

namespace EcommerceV4.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty();
        }
    }
}
