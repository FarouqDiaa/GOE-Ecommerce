using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductTranslationRepository
    {
        Task AddTranslationAsync(ProductTranslation productTranslation);
        Task<ProductTranslation> GetTranslationAsync(Guid productId, string language);
    }
}
