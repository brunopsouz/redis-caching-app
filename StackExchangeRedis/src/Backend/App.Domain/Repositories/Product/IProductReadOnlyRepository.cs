namespace App.Domain.Repositories.Product
{
    public interface IProductReadOnlyRepository
    {
        Task<Entities.Product> GetById(string code);
    }
}
