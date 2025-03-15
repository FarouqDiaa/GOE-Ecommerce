using AutoMapper;
using Application.DTOs.ProductTranslationDTOs;
using Domain.Entities;
using Presentation.ViewModels.ProductTranslation;

namespace Runtime.Mappings
{
    class ProductTranslationMappingProfile : Profile
    {
        public ProductTranslationMappingProfile()
        {
            CreateMap<ProductTranslationViewModel, NewProductTranslationDTO>().ReverseMap();
            CreateMap<NewProductTranslationDTO, ProductTranslation>().ReverseMap();
        }
    }
}
