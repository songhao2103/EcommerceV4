using EcommerceV4.Domain.Common.Interfaces;

namespace EcommerceV4.Infrastructure.Services
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        private const int _workFactor = 12; // độ mạnh, càng cao càng chậm
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, _workFactor);
        }

        public bool VerifyPassword(string hashedPassword, string plainPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
