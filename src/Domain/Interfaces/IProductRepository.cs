using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task UpdateProductAsync(Product product);
        Task RemoveProductAsync(Product product);
    }
}
