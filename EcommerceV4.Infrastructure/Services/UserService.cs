using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Application.Features.Users.Commands.RegisterUser;
using EcommerceV4.Domain.Aggregates.UserAggregate;
using EcommerceV4.Domain.Aggregates.UserAggregate.Interfaces;
using EcommerceV4.Domain.Common.Interfaces;
using EcommerceV4.Domain.Common.ValueObjects;
using EcommerceV4.Domain.Repositories;

namespace EcommerceV4.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRepository<User> _userRepository;

        public UserService(IUserDomainService userDomainService, IPasswordHasher passwordHasher, IRepository<User> userRepository)
        {
            _userDomainService = userDomainService;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserNoSaveChange(RegisterUserCommand command)
        {
            var validEmail = await _userDomainService.ValidateUserAccount(command.Email);

            if (!validEmail)
            {
                throw new Exception("Email already exists");
            }

            var address = AddressObject.Create(command.AddressDetail, command.City, command.District, command.Commune);

            string passwordHashed = _passwordHasher.HashPassword(command.Password);

            var user = User.Create(
                command.Email,
                command.UserName,
                passwordHashed,
                command.AvatarUrl,
                //address,
                command.PhoneNumber
                );

            _userRepository.Add(user);

            return user;
        }
    }
}
