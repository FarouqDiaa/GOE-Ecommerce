using Application.Abstractions.UserUseCases;
using Application.DTOs.UserDTOs;
using Application.Exceptions.UserExceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.Abstractions.Services;
using BCrypt.Net;
using Application.DTOs.LoginDTO;

namespace Application.UseCases.UserUseCases
{
    public class LogInUseCase : ILogInUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public LogInUseCase(IUserRepository userRepository, IMapper mapper, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<string> ExecuteAsync(LoginDTO loginDTO)
        {
            // Fetch user by email
            var user = await _userRepository.GetUserByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid login credentials.");
            }

            // Verify password using BCrypt
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Invalid login credentials.");
            }

            // Map to UserDTO for token generation
            var userDTO = _mapper.Map<UserDTO>(user);

            // Generate JWT token
            return _jwtService.GenerateAccessToken(userDTO);
        }
    }
}
