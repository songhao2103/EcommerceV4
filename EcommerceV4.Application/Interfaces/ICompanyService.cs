using EcommerceV4.Application.Commands;


namespace EcommerceV4.Application.Interfaces
{
    public interface ICompanyService
    {
        public Task CreateCompanyAsync(CompanyCommand companyCommand);
    }
}
