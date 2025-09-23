using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Domain.Aggregates.CompanyAggregate.Interfaces
{
    public interface ICompanyDomainService
    {
        public Task ValidateCompanyNameAsync(string name);
    }
}
