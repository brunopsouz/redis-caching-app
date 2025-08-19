using App.Domain.Repositories;

namespace App.Infrastructure.DataAccess
{
    /// <summary>
    /// Classe criada para boas praticas. Implementar separado o commit/save changes no banco. 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductAppDbContext _dbContext;

        public UnitOfWork(ProductAppDbContext dbContext) => _dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();

    }
}
