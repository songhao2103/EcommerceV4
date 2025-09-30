using EcommerceV4.Domain.Aggregates.CompanyAggregate.Interfaces;

namespace EcommerceV4.Domain.Aggregates.CompanyAggregate
{
    public class CompanyDomainService : ICompanyDomainService
    {
        private readonly ICompanyChecker _checker;

        public CompanyDomainService(ICompanyChecker checker)
        {
            _checker = checker;
        }

        public async Task ValidateCompanyNameAsync(string name)
        {
            var isValid = await _checker.IsNameTakenAsync(name);

            if(isValid)
            {
                throw new Exception("Duplicate company name");
            }
        }
    }
}
