using EcommerceV4.Domain.Aggregates.UserAggregate.Enums;

namespace EcommerceV4.Application.DTOs
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        //public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public UserRole Role { get; set; }
    }
}

