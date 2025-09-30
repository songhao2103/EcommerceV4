using System.Reflection.Metadata.Ecma335;
using EcommerceV4.Application.Common.Abstractions.Responses;
using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Aggregates.CompanyAggregate.Interfaces;
using EcommerceV4.Domain.Common.ValueObjects;
using EcommerceV4.Domain.Repositories;
using MediatR;

namespace EcommerceV4.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ApiResponseHasData<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Company> _companyRepository;
        private readonly ICompanyDomainService _domainService;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, ICompanyDomainService domainService, IRepository<Company> companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _domainService = domainService;
        }

        // CancellationToken:
        // + Là một cơ chế để thông báo hủy một tác vụ đang chạy bất đồng bộ
        // + Trong trường hợp ở dưới thì nó được truyền vào SaveChange để ngừng commit khi request bị hủy
        public async Task<ApiResponseHasData<int>> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            if(command == null)
            {
                throw new ArgumentException("Missing data!");
            }

            await _domainService.ValidateCompanyNameAsync(command.CompanyName);

            var address = new AddressObject(command.AddressDetail, command.City, command.District, command.Commune);

            var entity = Company.Create(command.CompanyName, command.Description, address);

            _companyRepository.Add(entity);

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return ApiResponseHasData<int>.Ok(entity.Id);
        }
    }
}
