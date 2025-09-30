using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Application.DTOs;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;

namespace EcommerceV4.Infrastructure.Services
{
    public class GoogleAuthService : IExternalAuthService<GoogleJsonWebSignaturePayload>
    {
        private string? _googleClientId;

        public GoogleAuthService(IConfiguration configuration)
        {
            _googleClientId = configuration["Authentication:Google:ClientId"];
        }

        public async Task<GoogleJsonWebSignaturePayload?> VerifyGoogleTokenAsync(string idToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new[] { _googleClientId }
            };

           
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

                if(payload == null)
                {
                    throw new Exception($"Payload is null");
                }
                return new GoogleJsonWebSignaturePayload()
                {
                    Email = payload.Email,
                    EmailVerified = payload.EmailVerified,
                    FamilyName = payload.FamilyName,
                    GivenName = payload.GivenName,
                    HostedDomain = payload.HostedDomain,
                    Locale = payload.Locale,
                    Name = payload.Name,
                    Picture = payload.Picture,
                    Prn = payload.Prn,
                    Scope = payload.Scope,
                };
            }
            catch (InvalidJwtException ex)
            {
                // Token sai, hết hạn, hoặc không khớp audience
                throw new Exception($"Invalid token: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception("Login failed!");
            }
        }
    }
}
