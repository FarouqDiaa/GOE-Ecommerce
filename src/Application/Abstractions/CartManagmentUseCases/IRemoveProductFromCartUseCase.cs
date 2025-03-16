

namespace Application.Abstractions.CartManagmentUseCases
{
    public interface IRemoveProductFromCartUseCase
    {
        Task ExecuteAsync(Guid userId, Guid productId);
    }
}
