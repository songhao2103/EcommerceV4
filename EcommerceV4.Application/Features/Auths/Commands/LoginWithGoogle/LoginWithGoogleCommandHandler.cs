using EcommerceV4.Application.Common.Abstractions.Responses;
using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Application.DTOs;
using EcommerceV4.Application.Features.Users.Commands.RegisterUser;
using EcommerceV4.Domain.Aggregates.UserAggregate;
using EcommerceV4.Domain.Repositories;
using MediatR;

namespace EcommerceV4.Application.Features.Auths.Commands.LoginWithGoogle
{
    internal class LoginWithGoogleCommandHandler : IRequestHandler<LoginWithGoogleCommand, ApiResponseHasData<ResponseLoginDto>>
    {
        private readonly IExternalAuthService<GoogleJsonWebSignaturePayload> _externalAuthService;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public LoginWithGoogleCommandHandler(
            IExternalAuthService<GoogleJsonWebSignaturePayload> externalAuthService,
            IAuthService authService,
            IRepository<User> userRepository,
            IUnitOfWork unitOfWork,
            IUserService userService    
            )
        {
            _externalAuthService = externalAuthService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _authService = authService;
            _userService = userService;
        }


        public async Task<ApiResponseHasData<ResponseLoginDto>> Handle(LoginWithGoogleCommand request, CancellationToken cancellationToken)
        {
            var payload = await _externalAuthService.VerifyGoogleTokenAsync(request.Credential);

            if (payload == null) throw new UnauthorizedAccessException();

            if(string.IsNullOrEmpty(payload.Email))
            {
                throw new UnauthorizedAccessException();
            }    

            var user = await _userRepository.GetOneAsync(u => u.Email.Value == payload.Email);
            
            if(user == null)
            { 
                var userCommand = new RegisterUserCommand
                {
                    UserName = payload.Name,
                    Email = payload.Email,
                    AvatarUrl = payload.Picture,
                    AddressDetail = ""
                };

                user = await _userService.CreateUserNoSaveChange(userCommand);
            }

            var result = await _authService.CreateResponseLogin(user);

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return ApiResponseHasData<ResponseLoginDto>.Ok(result);
        }
    }
}
