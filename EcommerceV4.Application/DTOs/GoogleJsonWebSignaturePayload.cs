namespace EcommerceV4.Application.DTOs
{
    public class GoogleJsonWebSignaturePayload
    {
        public string? Scope { get; set; }
        public string? Prn { get; set; }
        public string? HostedDomain { get; set; }
        public string? Email { get; set; }
        public bool? EmailVerified { get; set; }
        public string? Name { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
        public string? Picture { get; set; }
        public string? Locale { get; set; }
    }
}
