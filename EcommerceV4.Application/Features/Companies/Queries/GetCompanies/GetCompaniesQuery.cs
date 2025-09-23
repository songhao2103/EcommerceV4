using EcommerceV4.Application.Common;
using MediatR;

namespace EcommerceV4.Application.Features.Companies.Queries.GetCompanies
{
    public class GetCompaniesQuery : BaseQuery, IRequest<List<GetComapiesResponseDto>>
    {

    }
}
