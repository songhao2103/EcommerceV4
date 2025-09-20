using EcommerceV4.Domain.Aggregates.CompanyAggregate.Services;
using EcommerceV4.Domain.Repositories;
using MediatR;

namespace EcommerceV4.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CompanyDomainService _domainService;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, CompanyDomainService domainService)
        {
            _unitOfWork = unitOfWork;
            _domainService = domainService;
        }

        // CancellationToken:
        // + Là một cơ chế để thông báo hủy một tác vụ đang chạy bất đồng bộ
        // + Trong trường hợp ở dưới thì nó được truyền vào SaveChange để ngừng commit khi request bị hủy
        public async Task<int> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            if(command == null)
            {
                return 0;
            }

            var entity = command.ToEntity();

            entity = await _domainService.ValidateCompanyNameAsync(entity);

            _unitOfWork.CompanyRepository.Add(entity);

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return entity.Id;
        }
    }
}
