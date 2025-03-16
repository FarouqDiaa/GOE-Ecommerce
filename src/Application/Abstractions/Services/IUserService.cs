using Application.DTOs.LoginDTO;
using Application.DTOs.UserDTOs;
using Domain.Entities;

namespace Application.Abstractions.Services
{
    public interface IUserService
    {
        public Task<string> RegisterUserAsync(SignUpDTO signUpDTO);
        public Task<string> LoginUserAsync(LoginDTO loginDTO);
        Task<UserDTO> GetUserDetailsAsync(Guid userId);
        Task DeleteUserAsync(Guid userId);
    }
}
