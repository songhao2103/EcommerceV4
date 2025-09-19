using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public string? UrlImageDefault { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; } 
        public int StoreId { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
        public Order? Order { get; set; }
    }
}
