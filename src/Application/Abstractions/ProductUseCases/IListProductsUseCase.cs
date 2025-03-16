

using Application.DTOs.ProductDTOs;

namespace Application.Abstractions.ProductUseCases
{
    public interface IListProductsUseCase
    {
        Task<IEnumerable<ProductDTO>> ExecuteAsync();
    }
}
