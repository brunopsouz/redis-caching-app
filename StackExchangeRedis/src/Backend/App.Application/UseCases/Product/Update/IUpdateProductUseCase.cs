using App.Communication.Requests;

namespace App.Application.UseCases.Product.Update
{
    public interface IUpdateProductUseCase
    {
        Task Execute(RequestProductJson request);
    }
}
