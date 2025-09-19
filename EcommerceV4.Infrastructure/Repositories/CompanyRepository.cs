using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Infrastructure.Repositories
{
    internal class CompanyRepository : BaseRepository<Company>
    {
        public CompanyRepository(EcommerceDbContext dbContext) : base(dbContext) { }
    }
}
