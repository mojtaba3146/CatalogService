using Category.Domain.CommanInterfaces;

namespace Category.Infrastructure
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly CatalogDbContext _dataContext;

        public EFUnitOfWork(CatalogDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Begin()
        {
            await _dataContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
            await _dataContext.Database.CommitTransactionAsync();
        }

        public async Task CommitPartial()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task Complete()
        {
            await _dataContext.SaveChangesAsync(); 
        }

        public async Task Rollback()
        {
            await _dataContext.Database.RollbackTransactionAsync();
        }
    }
}
