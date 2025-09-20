using System;
using EcommerceV4.Domain.Aggregates.ProductAggregate;
using EcommerceV4.Domain.Common.ValueObjects;

namespace EcommerceV4.Domain.Aggregates.OrderAggregate
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public ProductInfoObject? ProductInfo { get; set; }
        public int StoreId { get; set; }
        public MoneyObject Money { get; set; } = new MoneyObject();
        public int? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
        public Order? Order { get; set; }
    }
}
