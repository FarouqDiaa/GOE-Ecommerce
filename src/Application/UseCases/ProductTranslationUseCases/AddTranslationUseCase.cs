using Application.Abstractions.ProductTranslationUseCases;
using Application.DTOs.ProductTranslationDTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.ProductTranslationUseCases
{
    public class AddTranslationUseCase : IAddTranslationUseCase
    {
        private readonly IProductTranslationRepository _productTranslationRepository;
        private readonly IMapper _mapper;

        public AddTranslationUseCase(IProductTranslationRepository productTranslationRepository, IMapper mapper)
        {
            _productTranslationRepository = productTranslationRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(NewProductTranslationDTO newProductTranslationDTO)
        {
            var productTranslation = _mapper.Map<ProductTranslation>(newProductTranslationDTO);
            await _productTranslationRepository.AddTranslationAsync(productTranslation);
        }
    }
}
