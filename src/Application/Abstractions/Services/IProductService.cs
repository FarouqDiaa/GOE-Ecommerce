

using Application.DTOs.ProductDTOs;

namespace Application.Abstractions.Services
{
    public interface IProductService
    {
        Task AddProductAsync(NewProductDTO product);
        Task<ProductDTO> GetProductDetailsAsync(Guid productId);
        Task<IEnumerable<ProductDTO>> ListProductsAsync();
        Task RemoveProductsAsync(Guid productId);
        Task UpdateProductAsync(Guid productId, NewProductDTO product);

    }
}
