
using Application.DTOs.CartDTOs;

namespace Application.Abstractions.CartManagmentUseCases
{
    public interface IGetCartDetailsUseCase
    {
        Task<CartDTO> ExecuteAsync(Guid userId);
    }
}
