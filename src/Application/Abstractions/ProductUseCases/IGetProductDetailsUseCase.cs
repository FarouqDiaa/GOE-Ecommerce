

namespace Application.Abstractions.ProductUseCases
{
    public interface IGetProductDetailsUseCase
    {
        Task Execute(Guid productId);
    }
}
