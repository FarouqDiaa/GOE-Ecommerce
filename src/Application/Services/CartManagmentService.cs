using Application.Abstractions.Services;
using Application.Abstractions.CartManagmentUseCases;
using Application.DTOs.CartDTOs;
using Application.DTOs.ProductDTOs;

namespace Application.Services
{
    public class CartManagmentService : ICartManagmentService
    {
        private readonly IAddProductToCartUseCase _addProductToCartUseCase;
        private readonly IGetCartDetailsUseCase _getCartDetailsUseCase;
        private readonly IRemoveProductFromCartUseCase _removeProductFromCartUseCase;

        public CartManagmentService(
            IAddProductToCartUseCase addProductToCartUseCase,
            IGetCartDetailsUseCase getCartDetailsUseCase,
            IRemoveProductFromCartUseCase removeProductFromCartUseCase)
        {
            _addProductToCartUseCase = addProductToCartUseCase;
            _getCartDetailsUseCase = getCartDetailsUseCase;
            _removeProductFromCartUseCase = removeProductFromCartUseCase;
        }

        public async Task AddProductToCartAsync(ProductDTO productDTO, Guid userId)
        {
            await _addProductToCartUseCase.ExecuteAsync(productDTO, userId);
        }

        public async Task<CartDTO> GetCartDetailsAsync(Guid userId)
        {
            return await _getCartDetailsUseCase.ExecuteAsync(userId);
        }

        public async Task RemoveProductFromCartAsync(Guid productId, Guid userId)
        {
            await _removeProductFromCartUseCase.ExecuteAsync(productId, userId);
        }
    }
}
