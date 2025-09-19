namespace EcommerceV4.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        public void SaveChanges();
        public Task SaveChangeAsync();
    }
}
