

using Application.Abstractions.Services;
using Application.Abstractions.ProductTranslationUseCases;
using Application.DTOs.ProductTranslationDTOs;

namespace Application.Services
{
    public class ProductTranslationService : IProductTranslationService
    {
        private readonly IAddTranslationUseCase _addTranslationUseCase;
        private readonly IGetProductTranslationUseCase _getProductTranslationUseCase;

        public ProductTranslationService(IAddTranslationUseCase addTranslationUseCase, IGetProductTranslationUseCase getProductTranslationUseCase)
        {
            _addTranslationUseCase = addTranslationUseCase;
            _getProductTranslationUseCase = getProductTranslationUseCase;
        }

        public async Task AddTranslationAsync(NewProductTranslationDTO newProductTranslationDTO)
        {
            await _addTranslationUseCase.ExecuteAsync(newProductTranslationDTO);
        }

        public async Task<ProductTranslationDTO> GetProductTranslationAsync(Guid productId, string language)
        {
            return await _getProductTranslationUseCase.ExecuteAsync(productId, language);
        }
    }
}
