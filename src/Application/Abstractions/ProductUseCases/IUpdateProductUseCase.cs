

using Application.DTOs.ProductDTOs;

namespace Application.Abstractions.ProductUseCases
{
    public interface IUpdateProductUseCase
    {
        Task Execute(Guid productId, NewProductDTO product);
    }
}
