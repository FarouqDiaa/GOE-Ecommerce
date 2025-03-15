using Application.DTOs.UserDTOs;

namespace Application.Abstractions.UserUseCases
{
    public interface IGetUserDetailsUseCase
    {
        Task<UserDTO> ExecuteAsync(Guid userId);

    }
}
