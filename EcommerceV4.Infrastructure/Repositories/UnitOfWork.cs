using EcommerceV4.Domain.Aggregates.CompanyAggregate;
using EcommerceV4.Domain.Repositories;
using EcommerceV4.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;


namespace EcommerceV4.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(EcommerceDbContext context)
        {
            _dbContext = context;
        }

        private IRepository<Company>? _companyRepository;
        public IRepository<Company> CompanyRepository
        {
            get
            {
                if(_companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_dbContext);
                } 

                return _companyRepository;
            }
        }


        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if(_transaction != null)
            {
                await _transaction.CommitAsync();
            } 
        }

        public async Task RollbackTransactionAsync()
        {
            if(_transaction != null)
            {
                await _transaction.RollbackAsync();
            }   
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _dbContext?.Dispose();
        }
    }
}
