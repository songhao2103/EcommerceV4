using EcommerceV4.Application.Commands;
using EcommerceV4.Application.Interfaces;
using EcommerceV4.Domain.Repositories;
using FluentValidation;
namespace EcommerceV4.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCompanyAsync(CompanyCreateCommand companyCommand)
        {
            var entity = companyCommand.ToEntity();

            _unitOfWork.CompanyRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
