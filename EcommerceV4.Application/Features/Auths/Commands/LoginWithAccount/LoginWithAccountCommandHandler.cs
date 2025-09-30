using EcommerceV4.Application.Common.Abstractions.Responses;
using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Application.DTOs;
using EcommerceV4.Domain.Aggregates.UserAggregate;
using EcommerceV4.Domain.Common.Interfaces;
using EcommerceV4.Domain.Repositories;
using MediatR;

namespace EcommerceV4.Application.Features.Auths.Commands.LoginWithAccount
{
    internal class LoginWithAccountCommandHandler : IRequestHandler<LoginWithAccountCommand, ApiResponseHasData<ResponseLoginDto>>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthService _authService;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;


        public LoginWithAccountCommandHandler(IPasswordHasher passwordHasher, IRepository<User> userRepository, IAuthService authService, IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponseHasData<ResponseLoginDto>> Handle(LoginWithAccountCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetOneAsync(u => u.Email.Value == command.Email);

            if(user == null)
            {
                throw new InvalidOperationException("Email không đúng!");
            } 

            var validPassword = _passwordHasher.VerifyPassword(user.Password, command.Password);

            if(validPassword == false)
            {
                throw new InvalidOperationException("Mật khẩu không đúng");
            } 
                
            var result = await _authService.CreateResponseLogin(user);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return ApiResponseHasData<ResponseLoginDto>.Ok(result);
        }
    }
}
