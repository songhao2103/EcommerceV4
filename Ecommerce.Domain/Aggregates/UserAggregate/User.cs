using EcommerceV4.Domain.Aggregates.OrderAggregate;
using EcommerceV4.Domain.Aggregates.UserAggregate.Enums;
using EcommerceV4.Domain.Aggregates.UserAggregate.ValueObjects;
using EcommerceV4.Domain.Common.Abstractions;
using EcommerceV4.Domain.Common.ValueObjects;

namespace EcommerceV4.Domain.Aggregates.UserAggregate
{
    public class User : BaseAggregateRoot<int>
    {
        public EmailObject Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public AddressObject? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int? StoreId { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Active;
        public UserRole Role { get; set; } = UserRole.Customer;
        public List<Order>? Orders { get; set; }

        private User() { }
        public static User Create
            (
                string email,
                string userName,
                string password,
                string? avatar,
                //AddressObject? address,
                string? phoneNumber
            )
        {
            if (
                string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password)
                )
            {
                throw new ArgumentException("Data invalid!");
            }

            var emailObject = EmailObject.Create(email);
            

            return new User
            {
                Email = emailObject,
                UserName = userName,
                Password = password,
                //Address = address,
                PhoneNumber = phoneNumber,
                AvatarUrl = avatar,
            };
        }
    }
}
