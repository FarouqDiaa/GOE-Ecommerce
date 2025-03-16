

using Application.DTOs.ProductTranslationDTOs;

namespace Application.Abstractions.Services
{
    public interface IProductTranslationService
    {
        Task AddTranslationAsync(NewProductTranslationDTO newProductTranslationDTO);
        Task<ProductTranslationDTO> GetProductTranslationAsync(Guid productId, string language);
    }
}
