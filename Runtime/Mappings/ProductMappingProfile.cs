using AutoMapper;
using Presentation.ViewModels.ProductViewModels;
using Application.DTOs.ProductDTOs;
using Domain.Entities;

namespace Runtime.Mappings
{
    class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductViewModel, NewProductDTO>().ReverseMap();
            CreateMap<NewProductDTO, Product>().ReverseMap();
        }
    }
}
