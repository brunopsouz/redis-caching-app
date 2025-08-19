using App.Domain.Entities;

namespace App.Domain.Repositories.Product
{
    public interface IProductUpdateOnlyRepository
    {
        Task<Entities.Product> GetById(string code);
        void Update(Entities.Product product);
    }
}
