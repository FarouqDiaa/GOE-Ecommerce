

using Application.DTOs.ProductDTOs;

namespace Application.Abstractions.ProductUseCases
{
    public interface IUpdateProductUseCase
    {
        Task ExecuteAsync(Guid productId, NewProductDTO product);
    }
}
