
using Application.DTOs.ProductTranslationDTOs;

namespace Application.Abstractions.ProductTranslationUseCases
{
    interface IGetProductTranslationUseCase
    {
        Task<ProductTranslationDTO> ExecuteAsync(Guid productTranslationId);
    }
}
