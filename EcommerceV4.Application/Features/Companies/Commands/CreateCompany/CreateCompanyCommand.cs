using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using MediatR;

namespace EcommerceV4.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? AddressDetail { get; set; }

        public CreateCompanyCommand(string companyName, string? description, string? addressDetail)
        {
            CompanyName = companyName;
            Description = description;
            AddressDetail = addressDetail;
        }

        public Company ToEntity()
        {
            return new Company(CompanyName, Description, AddressDetail);
        }
    }
}
