namespace EcommerceV4.Domain.Common.Abstractions
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; } = default!;
        public DateTime? CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        public BaseEntity() 
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
