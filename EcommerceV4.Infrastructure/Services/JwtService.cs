using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EcommerceV4.Application.Common.Interfaces;
using EcommerceV4.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceV4.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(JwtClaimDto claim)
        {
            var jwtSetting = _configuration.GetSection("Jwt");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, claim.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, claim.UserName),
                new Claim(ClaimTypes.Role, claim.Role.ToString()),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //Tạo ra một Symmetric key (Khóa bí mật) để ký và verify JWT
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting["Key"]));

            //Là thuật toán ký
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                //Ai đã phát hành token này
                //Dùng để validate khi nhận token, chỉ chấp nhận token được phát hành từ issuer đúng
                issuer: jwtSetting["Issuer"],

                //Ai được phép dùng token này, thường là domain của client
                //Nếu token được gửi đến 1 API không phải là audience của nó thì sẽ bị từ chối
                audience: jwtSetting["Audience"],

                //Danh sách claims được add vào token
                claims: claims,

                //Thời điểm hết token
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSetting["ExpireMinutes"])),

                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal VerifyToken(string token)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero // không cho delay 5 phút mặc định
                };

                // out validated token nếu muốn lấy thêm info raw
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                return principal; // principal chứa User + Claims
            }
            catch
            {
                return null; // token không hợp lệ
            }
        }
    }
}
