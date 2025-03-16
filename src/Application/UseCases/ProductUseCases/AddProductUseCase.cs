using Application.Abstractions.ProductUseCases;
using Application.DTOs.ProductDTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.ProductUseCases
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddProductUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(NewProductDTO product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var productEntity = _mapper.Map<Product>(product);
            await _productRepository.AddProductAsync(productEntity);
        }
    }
}
