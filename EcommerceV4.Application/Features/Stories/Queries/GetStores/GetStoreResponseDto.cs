using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Application.Features.Stories.Queries.GetStores
{
    public class GetStoreResponseDto
    {
        public int Id { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
