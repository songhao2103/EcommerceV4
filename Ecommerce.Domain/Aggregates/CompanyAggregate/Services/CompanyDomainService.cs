namespace EcommerceV4.Domain.Aggregates.CompanyAggregate.Services
{
    public class CompanyDomainService : ICompanyDomainService
    {
        private readonly ICompanyChecker _checker;

        public CompanyDomainService(ICompanyChecker checker)
        {
            _checker = checker;
        }

        public async Task<Company> ValidateCompanyNameAsync(Company entity)
        {
            var valid = await _checker.IsNameTakenAsync(entity.CompanyName);

            if (valid)
            {
                entity.CompanyName = entity.CompanyName + "Đã bị trùng!";
            }
                
            return entity;
        }
    }
}
