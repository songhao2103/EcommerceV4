using EcommerceV4.Application.Common.Abstractions.Responses;
using MediatR;

namespace EcommerceV4.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<ApiResponseHasData<int>>
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string AddressDetail { get; set; } = string.Empty;
        public int? City { get; set; }
        public int? District { get; set; }
        public int? Commune { get; set; }
    }
}
