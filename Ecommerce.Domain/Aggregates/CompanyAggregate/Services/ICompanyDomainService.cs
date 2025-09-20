namespace EcommerceV4.Domain.Aggregates.CompanyAggregate.Services
{
    public interface ICompanyDomainService
    {
        public Task<Company> ValidateCompanyNameAsync(Company entity);
    }
}
