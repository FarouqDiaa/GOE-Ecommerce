
using Application.Abstractions.Services;
using Application.Abstractions.ProductUseCases;

using Application.DTOs.ProductDTOs;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IAddProductUseCase _addProductUseCase;
        private readonly IGetProductDetailsUseCase _getProductDetailsUseCase;
        private readonly IListProductsUseCase _listProductsUseCase;
        private readonly IRemoveProductUseCase _removeProductUseCase;
        private readonly IUpdateProductUseCase _updateProductUseCase;

        public ProductService(
            IAddProductUseCase addProductUseCase,
            IGetProductDetailsUseCase getProductDetailsUseCase,
            IListProductsUseCase listProductsUseCase,
            IRemoveProductUseCase removeProductUseCase,
            IUpdateProductUseCase updateProductUseCase)
        {
            _addProductUseCase = addProductUseCase;
            _getProductDetailsUseCase = getProductDetailsUseCase;
            _listProductsUseCase = listProductsUseCase;
            _removeProductUseCase = removeProductUseCase;
            _updateProductUseCase = updateProductUseCase;
        }

        public async Task AddProductAsync(NewProductDTO product)
        {
            await _addProductUseCase.ExecuteAsync(product);
        }

        public async Task<ProductDTO> GetProductDetailsAsync(Guid productId)
        {
            return await _getProductDetailsUseCase.ExecuteAsync(productId);
        }

        public async Task<IEnumerable<ProductDTO>> ListProductsAsync()
        {
            return await _listProductsUseCase.ExecuteAsync();
        }

        public async Task RemoveProductsAsync(Guid productId)
        {
            await _removeProductUseCase.ExecuteAsync(productId);
        }

        public async Task UpdateProductAsync(Guid productId, NewProductDTO product)
        {
            await _updateProductUseCase.ExecuteAsync(productId, product);
        }
    }
}
