

namespace Application.Abstractions.ProductUseCases
{
    public interface IRemoveProductUseCase
    {
        Task ExecuteAsync(Guid productId);
    }
}
