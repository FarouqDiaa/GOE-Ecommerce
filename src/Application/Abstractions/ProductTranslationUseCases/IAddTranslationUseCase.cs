

using Application.DTOs.ProductTranslationDTOs;

namespace Application.Abstractions.ProductTranslationUseCases
{
    public interface IAddTranslationUseCase
    {
        Task ExecuteAsync(NewProductTranslationDTO newProductTranslationDTO);
    }
}
