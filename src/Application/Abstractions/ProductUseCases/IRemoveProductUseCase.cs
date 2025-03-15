

namespace Application.Abstractions.ProductUseCases
{
    public interface IRemoveProductUseCase
    {
        Task Execute(Guid productId);
    }
}
