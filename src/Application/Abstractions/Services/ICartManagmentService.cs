
using Application.DTOs.CartDTOs;
using Application.DTOs.ProductDTOs;

namespace Application.Abstractions.Services
{
    public interface ICartManagmentService
    {
        Task AddProductToCartAsync(ProductDTO productDTO, Guid userId);
        Task RemoveProductFromCartAsync(Guid productId, Guid userId);
        Task<CartDTO> GetCartDetailsAsync(Guid userId);
    }
}
