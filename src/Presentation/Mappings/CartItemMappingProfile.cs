
using AutoMapper;
using Presentation.ViewModels.CartViewModels;
using Application.DTOs.CartItemDTOs;
using Domain.Entities;


namespace Runtime.Mappings
{
    class CartItemMappingProfile : Profile
    {
        public CartItemMappingProfile()
        {
            CreateMap<CartItemViewModel, NewCartItemDTO>().ReverseMap();
            CreateMap<NewCartItemDTO, CartItem>().ReverseMap();
        }
    }
}
