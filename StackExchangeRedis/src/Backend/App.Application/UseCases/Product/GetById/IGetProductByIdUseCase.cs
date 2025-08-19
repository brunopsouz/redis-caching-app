using App.Communication.Requests;
using App.Communication.Responses;

namespace App.Application.UseCases.Product.GetById
{
    public interface IGetProductByIdUseCase
    {
        public Task<ResponseProductJson> Execute(string code);
    }
}
