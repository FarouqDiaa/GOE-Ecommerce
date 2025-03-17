
using AutoMapper;
using Presentation.ViewModels.CartViewModels;
using Application.DTOs.CartDTOs;
using Domain.Entities;

namespace Runtime.Mappings
{
    class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<CartViewModel, NewCartDTO>().ReverseMap();
            CreateMap<NewCartDTO, Cart>().ReverseMap();
        }
    }
}
