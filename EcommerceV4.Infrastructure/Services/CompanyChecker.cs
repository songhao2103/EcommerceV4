using EcommerceV4.Domain.Aggregates.CompanyAggregate.Services;
using EcommerceV4.Domain.Repositories;


namespace EcommerceV4.Infrastructure.Services
{
    public class CompanyChecker : ICompanyChecker
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyChecker(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsNameTakenAsync(string name)
        {
            return await _unitOfWork.CompanyRepository.AnyAsync(c => c.CompanyName == name);
        }
    }
}
