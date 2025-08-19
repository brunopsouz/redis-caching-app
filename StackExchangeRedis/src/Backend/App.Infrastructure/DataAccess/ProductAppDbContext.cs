using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess
{
    public class ProductAppDbContext : DbContext
    {
        public ProductAppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductAppDbContext).Assembly);
        }

    }
}
