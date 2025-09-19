namespace EcommerceV4.Application.Commands
{
    public class CompanyCommand
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? AddressDetail { get; set; }

        public CompanyCommand(string companyName, string? description, string? addressDetail) 
        {
            CompanyName = companyName;
            Description = description;
            AddressDetail = addressDetail;
        }
    }
}
