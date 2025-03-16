using Application.Abstractions.Services;
using Application.DTOs.LoginDTO;
using Application.DTOs.UserDTOs;
using Application.Abstractions.UserUseCases;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRegisterUseCase _registerUserUseCase;
        private readonly ILogInUseCase _loginUserUseCase;
        private readonly IGetUserDetailsUseCase _getUserDetailsUseCase;
        private readonly IDeleteUserUseCase _deleteUserUseCase;

        public UserService(
            IRegisterUseCase registerUserUseCase,
            ILogInUseCase loginUserUseCase,
            IGetUserDetailsUseCase getUserDetailsUseCase,
            IDeleteUserUseCase deleteUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _loginUserUseCase = loginUserUseCase;
            _getUserDetailsUseCase = getUserDetailsUseCase;
            _deleteUserUseCase = deleteUserUseCase;
        }

        public async Task<string> RegisterUserAsync(SignUpDTO signUpDTO)
        {
            return await _registerUserUseCase.ExecuteAsync(signUpDTO);
        }

        public async Task<string> LoginUserAsync(LoginDTO loginDTO)
        {
            return await _loginUserUseCase.ExecuteAsync(loginDTO);
        }

        public async Task<UserDTO> GetUserDetailsAsync(Guid userId)
        {
            return await _getUserDetailsUseCase.ExecuteAsync(userId);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            await _deleteUserUseCase.ExecuteAsync(userId);
        }
    }
}
