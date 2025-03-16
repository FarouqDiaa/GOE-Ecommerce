
using Application.DTOs.UserDTOs;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Abstractions.Services
{
    public interface IJwtService
    {
        public string GenerateAccessToken(UserDTO user);
        public string GenerateRefreshToken(UserDTO user);
        public bool ValidateToken(string token);
    }
}
