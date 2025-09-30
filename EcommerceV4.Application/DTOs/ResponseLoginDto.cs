
namespace EcommerceV4.Application.DTOs
{
    public class ResponseLoginDto
    {
        public UserInfoDto UserInfo { get; set; } = new UserInfoDto();
        public string AccessToken { get; set; } = string.Empty;
        public string RefetchToken {  get; set; } = string.Empty;
    }
}
