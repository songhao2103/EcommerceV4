
using EcommerceV4.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV4.Application.Features.Companies.Queries.GetCompanies
{
    internal class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, List<GetComapiesResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompaniesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetComapiesResponseDto>> Handle(GetCompaniesQuery query, CancellationToken cancellationToken)
        {
            var queryable = _unitOfWork.CompanyRepository
                                .Query(c => string.IsNullOrEmpty(query.SearchKey) || c.CompanyName.Contains(query.SearchKey.ToLower()));

            var companies = await queryable.Skip((query.PageIndex - 1) * query.PageSize)
                                    .Take(query.PageSize)
                                    .Select(c => new GetComapiesResponseDto
                                    {
                                        Id = c.Id,
                                        CompanyName = c.CompanyName,
                                    }).ToListAsync();

            return companies;
        }
    }
}
