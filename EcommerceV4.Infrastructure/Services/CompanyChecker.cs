using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Aggregates.CompanyAggregate.Interfaces;
using EcommerceV4.Domain.Repositories;


namespace EcommerceV4.Infrastructure.Services
{
    public class CompanyChecker : ICompanyChecker
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyChecker(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> IsNameTakenAsync(string name)
        {
            return await _companyRepository.AnyAsync(c => c.CompanyName == name);
        }
    }
}
