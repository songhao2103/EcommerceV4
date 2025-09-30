using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EcommerceV4.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return null;
            }

            return int.TryParse(userIdClaim, out var userId) ? userId : null;
        }

        public static int GetUserIdHasActionResult(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                   ?? user.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                throw new UnauthorizedAccessException();
            }

            if(!int.TryParse(userIdClaim, out var userId))
            {
                throw new UnauthorizedAccessException();
            }    

            return userId;
        }
    }
}
