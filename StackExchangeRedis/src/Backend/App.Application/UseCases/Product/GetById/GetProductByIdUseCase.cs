using App.Communication.Requests;
using App.Communication.Responses;
using App.Domain.Entities;
using App.Domain.Repositories.Product;
using App.Domain.Services.Cache;
using AutoMapper;

namespace App.Application.UseCases.Product.GetById
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IProductReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly IRedisCacheService _cache;

        public GetProductByIdUseCase(
            IProductReadOnlyRepository repository,
            IMapper mapper,
            IRedisCacheService cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<ResponseProductJson> Execute(string code)
        {
            var cachedProduct = await _cache.GetAsync<ResponseProductJson>(code);

            if (cachedProduct is not null)
                return cachedProduct;

            var product = await _repository.GetById(code);

            var response = _mapper.Map<ResponseProductJson>(product);

            await _cache.SetData(response.Code, product);

            return response;
        }
    }
}
