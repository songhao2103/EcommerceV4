using EcommerceV4.Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Domain.Aggregates.CompanyAggregate
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? AddressDetail { get; set; }
        public List<Product>? Products { get; set; }

        public Company(string companyName, string? description, string? addressDetail)
        {
            CompanyName = companyName;
            Description = description;
            AddressDetail = addressDetail;
        }
    }
}
