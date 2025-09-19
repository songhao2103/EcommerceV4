namespace EcommerceV4.Domain.Common.ValueObjects
{
    public class MoneyObject
    {
        public decimal Price { get; private set; }
        public decimal Discount { get; private set; }

        public MoneyObject(decimal price, decimal discount)
        {
            if (price < 0) throw new ArgumentException("Price cannot be negative");
            if (discount < 0) throw new ArgumentException("Discount cannot be negative");
            if (discount > 100) throw new ArgumentException("Discount cannot be greater than 100");

            Price = price;
            Discount = discount;
        }

        public decimal FinalPrice => Price * (100 - Discount) / 100;
    }
}
