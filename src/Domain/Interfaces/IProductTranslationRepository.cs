using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductTranslationRepository
    {
        Task AddTranslationAsync(Guid productId, ProductTranslation productTranslation);
        Task<ProductTranslation> GetTranslationAsync(Guid productId, string language);
    }
}
