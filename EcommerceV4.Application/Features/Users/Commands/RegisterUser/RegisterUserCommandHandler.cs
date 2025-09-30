using EcommerceV4.Application.Common.Abstractions.Responses;
using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Domain.Aggregates.UserAggregate;
using EcommerceV4.Domain.Aggregates.UserAggregate.Interfaces;
using EcommerceV4.Domain.Common.Interfaces;
using EcommerceV4.Domain.Repositories;
using MediatR;

namespace EcommerceV4.Application.Features.Users.Commands.RegisterUser
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApiResponseHasData<int>>
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserDomainService userDomainService, IUnitOfWork unitOfWork, IRepository<User> userRepository, IPasswordHasher passwordHasher, IUserService userService)
        {
            _userDomainService = userDomainService;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userService = userService;
        }

        public async Task<ApiResponseHasData<int>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userService.CreateUserNoSaveChange(command);
            await _unitOfWork.SaveChangeAsync();
            return ApiResponseHasData<int>.Ok(user.Id);
        }
    }
}
