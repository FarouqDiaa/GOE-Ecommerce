

using Application.DTOs.ProductDTOs;

namespace Application.Abstractions.ProductUseCases
{
    public interface IGetProductDetailsUseCase
    {
        Task<ProductDTO> ExecuteAsync(Guid productId);
    }
}
