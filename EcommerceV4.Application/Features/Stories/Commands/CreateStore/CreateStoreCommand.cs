using MediatR;

namespace EcommerceV4.Application.Features.Stories.Commands.CreateStore
{
    public class CreateStoreCommand : IRequest<int>
    {
        public string StoreName { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public string AddressDetail { get; set; } = string.Empty;
        public int? City { get; set; }
        public int? District { get; set; }
        public int? Commune { get; set; }
    }
}
