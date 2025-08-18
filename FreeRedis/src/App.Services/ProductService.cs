using App.Model.Entities;
using App.Repositories.Interface;
using App.Services.Interface;

namespace App.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository) 
        {
            _repository = repository;
        }

        public Product GetProduct(string code) => _repository.GetProduct(code);

        public void AddProduct(Product product)
        {
            _repository.AddProduct(product);
        }

        public void DeleteProduct(string code)
        {
            _repository.DeleteProduct(code);
        }

    }
}
