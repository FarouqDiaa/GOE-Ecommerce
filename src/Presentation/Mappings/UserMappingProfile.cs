using AutoMapper;
using Presentation.ViewModels.UserViewModels;
using Domain.Entities;
using Application.DTOs.UserDTOs;

namespace Runtime.Mappings
{
    class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<SignUpViewModel, SignUpDTO>().ReverseMap();
            CreateMap<User, SignUpDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
        }
    }
}
