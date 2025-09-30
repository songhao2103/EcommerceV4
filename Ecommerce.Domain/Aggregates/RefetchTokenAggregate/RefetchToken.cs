using EcommerceV4.Domain.Common.Abstractions;

namespace EcommerceV4.Domain.Aggregates.RefetchTokenAggregate
{
    public class RefetchToken : BaseAggregateRoot<int>
    {
        public int Id { get; set; }
        public DateTime ExpireAt { get; set; }
        public DateTime? RevokeAt { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
        public bool IsActive => RevokeAt == null && !IsExpired;
        public bool IsExpired => DateTime.UtcNow >= ExpireAt;
        private RefetchToken() { }

        public RefetchToken(DateTime expireAt, string token, int userId)
        {
            ExpireAt = expireAt;
            RevokeAt = null;
            Token = token;
            UserId = userId;
        }
    }
}
