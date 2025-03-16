

using Application.Abstractions.ProductUseCases;
using Application.DTOs.ProductDTOs;
using AutoMapper;
using Domain.Interfaces;

namespace Application.UseCases.ProductUseCases
{
    public class GetProductDetailsUseCase : IGetProductDetailsUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailsUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> ExecuteAsync(Guid productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
