

using Application.Abstractions.ProductUseCases;
using Application.DTOs.ProductDTOs;
using AutoMapper;
using Domain.Interfaces;

namespace Application.UseCases.ProductUseCases
{
    public class ListProductsUseCase : IListProductsUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListProductsUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> ExecuteAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
