

using Application.Abstractions.ProductUseCases;
using Application.Exceptions.ProductExceptions;
using Domain.Interfaces;

namespace Application.UseCases.ProductUseCases
{
    public class RemoveProductUseCase : IRemoveProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public RemoveProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ExecuteAsync(Guid productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                throw new ProductNotFoundException("Product not found.");
            }

            await _productRepository.RemoveProductAsync(product);
        }
    }
}
