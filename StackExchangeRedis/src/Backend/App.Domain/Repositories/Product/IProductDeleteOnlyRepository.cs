namespace App.Domain.Repositories.Product
{
    public interface IProductDeleteOnlyRepository
    {
        Task<Entities.Product> DeleteById(int id);
    }
}
