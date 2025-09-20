

using MediatR;

namespace EcommerceV4.Application.Features.Companies.Queries.GetCompanies
{
    public class GetCompaniesQuery : IRequest<List<GetComapiesResponseDto>>
    {
        private int _pageSize;
        private int _pageIndex;
        private string? _searchKey;

        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value > 0 ? value : 10;
            }
        }

        public int PageIndex
        {
            get => _pageIndex;
            set
            {
                _pageIndex = value < 1 ? 1 : value;
            }
        }

        public string SearchKey
        {
            get => _searchKey;
            set
            {
                 _searchKey = value?.Trim() ?? string.Empty;
            }
        }
    }
}
