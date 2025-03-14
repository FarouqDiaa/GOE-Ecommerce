using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync(Guid cartId);
        Task CreateCartAsync(Cart cart);
        Task<bool> UserHasCartAsync(Guid userId);
        Task<Cart> GetCartByUserIdAsync(Guid userId);
        Task UpdateCartAsync(Cart cart);
        Task<CartItem> GetCartItemAsync(Guid cartId, Guid productId);
        Task AddCartItemAsync(CartItem cartItem);
        Task RemoveCartItemAsync(CartItem cartItem);
    }
}
