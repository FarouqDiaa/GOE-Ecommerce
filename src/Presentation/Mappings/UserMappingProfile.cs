using AutoMapper;
using Presentation.ViewModels.UserViewModels;
using Domain.Entities;
using Application.DTOs.UserDTOs;
using Application.DTOs.LoginDTO;

namespace Runtime.Mappings
{
    class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<SignUpViewModel, SignUpDTO>().ReverseMap();
            CreateMap<LoginViewModel, LoginDTO>().ReverseMap();
            CreateMap<User, SignUpDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
        }
    }
}
