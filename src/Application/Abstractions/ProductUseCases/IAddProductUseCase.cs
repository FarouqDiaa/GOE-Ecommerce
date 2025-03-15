
using Application.DTOs.ProductDTOs;
namespace Application.Abstractions.ProductUseCases
{
    public interface IAddProductUseCase
    {
        Task Execute(NewProductDTO product);
    }
}
