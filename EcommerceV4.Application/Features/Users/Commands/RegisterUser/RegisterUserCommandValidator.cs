using FluentValidation;

namespace EcommerceV4.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.RePassword).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.UserName).NotEmpty();
        }
    }
}
