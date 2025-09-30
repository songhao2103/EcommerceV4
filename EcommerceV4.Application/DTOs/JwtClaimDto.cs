using EcommerceV4.Domain.Aggregates.UserAggregate.Enums;

namespace EcommerceV4.Application.DTOs
{
    public class JwtClaimDto
    {
        public string UserName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public UserRole Role { get; set; }
    }
}
