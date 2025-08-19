using App.Communication.Requests;
using App.Communication.Responses;

namespace App.Application.UseCases.Product.Register
{
    public interface IRegisterProductUseCase
    {
        public Task<ResponseProductJson> Execute(RequestProductJson request);
    }
}
