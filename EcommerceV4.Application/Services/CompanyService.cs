using EcommerceV4.Application.Commands;
using EcommerceV4.Application.Interfaces;
using EcommerceV4.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Application.Services
{
    internal class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public async Task CreateCompanyAsync(CompanyCommand companyCommand)
        {

        }
    }
}
