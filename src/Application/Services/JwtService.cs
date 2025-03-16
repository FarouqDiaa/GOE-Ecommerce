using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Application.Abstractions.Services;
using Application.DTOs.UserDTOs;

namespace Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly string _jwtSecret;
        private readonly string _jwtIssuer;
        private readonly string _jwtAudience;

        public JwtService()
        {
            _jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET")!;
            _jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")!;
            _jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")!;
        }

        private string GenerateToken(Claim[] claims, DateTime expires)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                Issuer = _jwtIssuer,
                Audience = _jwtAudience,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateAccessToken(UserDTO user)
        {
            if ( user.Email == null)
                throw new Exception("Invalid user data");

            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("createdAt", DateTime.UtcNow.ToString("o"))
            };

            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(Environment.GetEnvironmentVariable("JWT_ACCESS_EXPIRATION") ?? "30"));
            return GenerateToken(claims, expiration);
        }

        public string GenerateRefreshToken(UserDTO user)
        {
            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var expiration = DateTime.UtcNow.AddDays(Convert.ToDouble(Environment.GetEnvironmentVariable("JWT_REFRESH_EXPIRATION") ?? "7"));
            return GenerateToken(claims, expiration);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSecret);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = _jwtIssuer,
                    ValidAudience = _jwtAudience
                }, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
