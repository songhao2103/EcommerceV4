using EcommerceV4.Application.DTOs;

namespace EcommerceV4.Application.Common.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(JwtClaimDto claim);
    }
}
