using Application.Abstractions.UserUseCases;
using Application.DTOs.UserDTOs;
using Application.Exceptions.UserExceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.Abstractions.Services;

namespace Application.UseCases.UserUseCases
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public RegisterUseCase(IUserRepository userRepository, IMapper mapper, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }
        public async Task<string> ExecuteAsync(SignUpDTO signUpDTO)
        {
            // Check if the user already exists
            var existingUser = await _userRepository.UserExistsAsync(signUpDTO.Email);
            if (existingUser)
            {
                throw new EmailUsedException("User with this email already exists.");
            }

            // Map the DTO to a User entity
            var newUser = _mapper.Map<User>(signUpDTO);

            // Hash the password before saving
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(signUpDTO.Password);

            // Save the new user to the repository
            await _userRepository.RegisterAsync(newUser);

            // Map to UserDTO for token generation
            var userDTO = _mapper.Map<UserDTO>(newUser);

            // Generate JWT token
            return _jwtService.GenerateAccessToken(userDTO);
        }

    }
}
