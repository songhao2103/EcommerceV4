using EcommerceV4.Domain.Aggregates.CompanyAggregate;

namespace EcommerceV4.Application.Commands
{
    public class CompanyCreateCommand
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? AddressDetail { get; set; }

        public CompanyCreateCommand(string companyName, string? description, string? addressDetail) 
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
