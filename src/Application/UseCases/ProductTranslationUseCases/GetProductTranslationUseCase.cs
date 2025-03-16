

using Application.Abstractions.ProductTranslationUseCases;
using Application.DTOs.ProductTranslationDTOs;
using AutoMapper;
using Domain.Interfaces;

namespace Application.UseCases.ProductTranslationUseCases
{
    public class GetProductTranslationUseCase : IGetProductTranslationUseCase
    {
        private readonly IProductTranslationRepository _repository;
        private readonly IMapper _mapper;

        public GetProductTranslationUseCase(IProductTranslationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductTranslationDTO> ExecuteAsync(Guid productId, string language)
        {
            var productTranslation = await _repository.GetTranslationAsync(productId, language);
            if (productTranslation == null)
            {
                throw new KeyNotFoundException("Product translation not found.");
            }

            return _mapper.Map<ProductTranslationDTO>(productTranslation);
        }
    }
}
