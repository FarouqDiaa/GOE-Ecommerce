
using Application.DTOs.ProductTranslationDTOs;

namespace Application.Abstractions.ProductTranslationUseCases
{
    public interface IGetProductTranslationUseCase
    {
        Task<ProductTranslationDTO> ExecuteAsync(Guid productId, string language);
    }
}
