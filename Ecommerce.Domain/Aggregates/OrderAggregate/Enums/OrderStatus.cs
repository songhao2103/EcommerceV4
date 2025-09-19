namespace EcommerceV4.Domain.Aggregates.OrderAggregate.Enums
{
    public enum OrderStatus
    {
        Created,
        Accepted,
        StoreRefused,
        CustomerRefused,
        Shipping,
        Completed,
    }
}
