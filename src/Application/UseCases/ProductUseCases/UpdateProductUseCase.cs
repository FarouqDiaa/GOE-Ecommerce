

using Application.Abstractions.ProductUseCases;
using Application.DTOs.ProductDTOs;
using Application.Exceptions.ProductExceptions;
using AutoMapper;
using Domain.Interfaces;

namespace Application.UseCases.ProductUseCases
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(Guid productId, NewProductDTO product)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(productId);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException("Product not found");
            }

            _mapper.Map(product, existingProduct);
            await _productRepository.UpdateProductAsync(existingProduct);
        }
    }
}
