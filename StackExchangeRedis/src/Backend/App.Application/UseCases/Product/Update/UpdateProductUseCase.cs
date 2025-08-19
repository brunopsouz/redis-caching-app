using App.Communication.Requests;
using App.Domain.Repositories;
using App.Domain.Repositories.Product;
using AutoMapper;

namespace App.Application.UseCases.Product.Update
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductUpdateOnlyRepository _updateOnlyRepository;
        private readonly IUnitOfWork _commit;
        private readonly IMapper _mapper;

        public UpdateProductUseCase(IProductUpdateOnlyRepository updateOnlyRepository,
            IUnitOfWork commit,
            IMapper mapper)
        {
            _updateOnlyRepository = updateOnlyRepository;
            _commit = commit;
            _mapper = mapper;
        }

        public async Task Execute(RequestProductJson request)
        {
            var map = _mapper.Map<Domain.Entities.Product>(request);

            var product = await _updateOnlyRepository.GetById(request.Code);
            
            product.Code = request.Code;
            product.Description = request.Description;
            product.Price = request.Price;
            
            _updateOnlyRepository.Update(product);

            await _commit.Commit();
        }
    }
}
