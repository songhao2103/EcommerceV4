using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Domain.Aggregates.OrderAggregate
{
    public class AddressObject
    {
        public string? AddressDetail { get; set; }
        public int? City { get; set; }
        public int? District { get; set; }
        public int? Commune { get; set; }

        public AddressObject(string? addressDetail, int? city, int? district, int? commune)
        {
            AddressDetail = addressDetail;
            City = city;
            District = district;
            Commune = commune;
        }
    }
}
