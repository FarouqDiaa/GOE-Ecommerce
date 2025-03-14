using Domain.Entities;

namespace Domain.Interfaces
{
    interface ICartRepository
    {
        Task AddProductToCartAsync(Guid userId, Guid productId, int quantity);
        Task RemoveProductFromCartAsync(Guid userId, Guid productId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(Guid userId);
    }
}
