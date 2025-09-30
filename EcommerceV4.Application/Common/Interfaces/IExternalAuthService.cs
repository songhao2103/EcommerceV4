
namespace EcommerceV4.Application.Common.Interfaces
{
    public interface IExternalAuthService<T>
    {
        public Task<T?> VerifyGoogleTokenAsync(string idToken);
    }
}
