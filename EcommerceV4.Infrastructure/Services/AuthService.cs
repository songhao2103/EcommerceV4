using System.Security.Cryptography;
using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Application.DTOs;
using EcommerceV4.Domain.Aggregates.RefetchTokenAggregate;
using EcommerceV4.Domain.Aggregates.UserAggregate;
using EcommerceV4.Domain.Repositories;

namespace EcommerceV4.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<RefetchToken> _refetchTokenRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public AuthService(IRepository<RefetchToken> refetchTokenRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _refetchTokenRepository = refetchTokenRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<ResponseLoginDto> CreateResponseLogin(User user)
        {
            if(user == null)
            {
                throw new Exception("User not found");
            } 

            var refetchToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            var entity = new RefetchToken(DateTime.UtcNow.AddDays(1), refetchToken, user.Id);

            _refetchTokenRepository.Add(entity);

            var userInfo = new UserInfoDto
            {
                Id = user.Id,
                AvatarUrl = user.AvatarUrl,
                Email = user.Email.Value,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                UserName = user.UserName,
            };

            var claim = new JwtClaimDto
            {
                Role = user.Role,
                UserId = user.Id,
                UserName = user.UserName,
            };

            var accessToken = _jwtService.GenerateToken(claim);

            return new ResponseLoginDto
            {
                AccessToken = accessToken,
                RefetchToken = refetchToken,
                UserInfo = userInfo,
            };
        }
    }
}
