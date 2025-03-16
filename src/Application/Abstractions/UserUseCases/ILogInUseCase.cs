using Application.DTOs.LoginDTO;

namespace Application.Abstractions.UserUseCases
{
    public interface ILogInUseCase
    {
        public Task<string> ExecuteAsync(LoginDTO loginDTO);

    }
}
