using EcommerceV4.Application.Common.Abstractions.Responses;
using EcommerceV4.Domain.Aggregates.StoreAggregate;
using EcommerceV4.Domain.Aggregates.StoreAggregate.Interfaces;
using EcommerceV4.Domain.Common.ValueObjects;
using EcommerceV4.Domain.Repositories;
using MediatR;

namespace EcommerceV4.Application.Features.Stories.Commands.CreateStore
{
    internal class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Store> _storeRepository;
        private readonly IStoreDomainService _domainService;

        public CreateStoreCommandHandler(IUnitOfWork unitOfWork, IRepository<Store> storeRepository, IStoreDomainService domainService)
        {
            _unitOfWork = unitOfWork;
            _storeRepository = storeRepository;
            _domainService = domainService;
        }

        public async Task<ApiResponse> Handle(CreateStoreCommand command, CancellationToken cancellationToken)
        {
            await _domainService.ValidateStoreNameAsync(command.StoreName);

            var address = new AddressObject(command.AddressDetail, command.City, command.District, command.Commune);
            var entity = Store.Create(command.StoreName, command.AvatarUrl, address);

            _storeRepository.Add(entity);

            await _unitOfWork.SaveChangeAsync(cancellationToken);
            
            return ApiResponse.Ok($"Thêm store thành công! {entity.StoreName}");
        }
    }
}
