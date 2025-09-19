using System;
using EcommerceV4.Domain.ValueObjects;

namespace EcommerceV4.Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public ProductInfoObject? ProductInfo { get; set; }
        public int StoreId { get; set; }
        public MoneyObject? Money { get; set; }
        public int? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
        public Order? Order { get; set; }
    }
}
