using Application.DTOs.UserDTOs;

namespace Application.Abstractions.UserUseCases
{
    public interface IRegisterUseCase
    {
        public Task<string> ExecuteAsync(SignUpDTO signUpDTO);

    }
}
