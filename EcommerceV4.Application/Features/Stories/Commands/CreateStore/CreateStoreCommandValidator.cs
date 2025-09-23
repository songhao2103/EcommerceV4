using FluentValidation;

namespace EcommerceV4.Application.Features.Stories.Commands.CreateStore
{
    public class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator() 
        {
            RuleFor(s => s.StoreName).NotEmpty();
        }
    }
}
