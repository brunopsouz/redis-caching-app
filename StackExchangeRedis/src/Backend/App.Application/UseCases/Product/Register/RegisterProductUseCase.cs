using App.Communication.Requests;
using App.Communication.Responses;
using App.Domain.Entities;
using App.Domain.Repositories;
using App.Domain.Repositories.Product;
using AutoMapper;

namespace App.Application.UseCases.Product.Register
{
    public class RegisterProductUseCase : IRegisterProductUseCase
    {
        private readonly IMapper _mapper;
        private readonly IProductWriteOnlyRepository _writeOnlyRepository;
        private readonly IUnitOfWork _commit;

        public RegisterProductUseCase(
            IMapper mapper,
            IProductWriteOnlyRepository writeOnlyRepository,
            IUnitOfWork commit)
        {
            _mapper = mapper;
            _writeOnlyRepository = writeOnlyRepository;
            _commit = commit;
        }

        public async Task<ResponseProductJson> Execute(RequestProductJson request)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);

            await _writeOnlyRepository.Add(product);

            await _commit.Commit();

            return new ResponseProductJson
            {
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
            };
        }
    }
}
