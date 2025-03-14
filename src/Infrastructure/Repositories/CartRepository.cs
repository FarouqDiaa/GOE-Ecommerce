
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCartItemAsync(CartItem cartItem)
        {
            _context.Set<CartItem>().Add(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCartAsync(Cart cart)
        {
            _context.Set<Cart>().Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCartByUserIdAsync(Guid userId)
        {
            return await _context.Set<Cart>()
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(Guid cartId)
        {
            return await _context.Set<CartItem>()
                .Where(ci => ci.CartId == cartId)
                .ToListAsync();
        }

        public async Task<CartItem> GetCartItemAsync(Guid cartId, Guid productId)
        {
            return await _context.Set<CartItem>()
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);
        }

        public async Task RemoveCartItemAsync(CartItem cartItem)
        {
            _context.Set<CartItem>().Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            _context.Set<Cart>().Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserHasCartAsync(Guid userId)
        {
            return await _context.Set<Cart>().AnyAsync(c => c.UserId == userId);
        }

    }
}
