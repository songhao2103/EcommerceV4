namespace EcommerceV4.Domain.Common.ValueObjects
{
    public class AddressObject
    {
        public string AddressDetail { get; private set; } = string.Empty;
        public int? City { get; private set; }
        public int? District { get; private set; }
        public int? Commune { get; private set; }

        public AddressObject(string addressDetail, int? city, int? district, int? commune)
        {
            AddressDetail = addressDetail.Trim();
            City = city;
            District = district;
            Commune = commune;
        }
    }
}
