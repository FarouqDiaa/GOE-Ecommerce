
using Application.DTOs.ProductDTOs;

namespace Application.Abstractions.CartManagmentUseCases
{
    public interface IAddProductToCartUseCase
    {
        Task ExecuteAsync(ProductDTO productDTO, Guid userId);
    }
}
