using App.Model.Entities;

namespace App.Services.Interface
{
    public interface IProductService
    {
        void AddProduct(Product product);
        Product GetProduct(string code);
        void DeleteProduct(string code);
    }
}
