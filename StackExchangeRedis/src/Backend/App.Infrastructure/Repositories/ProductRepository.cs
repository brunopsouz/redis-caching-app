using App.Domain.Entities;
using App.Domain.Repositories.Product;
using App.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class ProductRepository : IProductReadOnlyRepository, IProductUpdateOnlyRepository, IProductDeleteOnlyRepository, IProductWriteOnlyRepository
    {
        private readonly ProductAppDbContext _dbContext;

        public ProductRepository(ProductAppDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(Product product) => await _dbContext.Products.AddAsync(product);

        public async Task<Product> GetById(string code)
        {
            return await _dbContext
                .Products
                .FirstAsync(p => p.Code == code);
        }

        public void Update(Product product) => _dbContext.Products.Update(product);

        public async Task<Product> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
