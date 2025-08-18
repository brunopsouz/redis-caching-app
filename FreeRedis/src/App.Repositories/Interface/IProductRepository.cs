using App.Model.Entities;

namespace App.Repositories.Interface
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProduct(string code);
        void DeleteProduct(string code);
    }
}
