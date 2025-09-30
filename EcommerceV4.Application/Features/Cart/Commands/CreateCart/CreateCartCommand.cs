using EcommerceV4.Application.Common.Abstractions.Responses;
using MediatR;

namespace EcommerceV4.Application.Features.Carts.Commands.CreateCart
{
    public class CreateCartCommand : IRequest<ApiResponse>
    {
        public int UserId { get; set; }
        public IEnumerable<CreateCartDetailCommand> CartDetails { get; set; }
    }
}
