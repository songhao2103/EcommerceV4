namespace EcommerceV4.Domain.Common.Interfaces
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string hashedPassword, string plainPassword);
    }
}
