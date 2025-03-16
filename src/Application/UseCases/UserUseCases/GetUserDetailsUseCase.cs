
using Application.Abstractions.UserUseCases;
using Application.DTOs.UserDTOs;
using Application.Exceptions.UserExceptions;
using AutoMapper;
using Domain.Interfaces;

namespace Application.UseCases.UserUseCases
{
    public class GetUserDetailsUseCase : IGetUserDetailsUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailsUseCase(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> ExecuteAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException("User not found.");
            }

            return _mapper.Map<UserDTO>(user);
        }
    }
}
