
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductTranslationRepository : IProductTranslationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ProductTranslationRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task AddTranslationAsync(ProductTranslation productTranslation)
        {
            _context.ProductTranslations.Add(productTranslation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ProductTranslation> GetTranslationAsync(Guid productId, string language)
        {
            var translation = await _context.ProductTranslations
                .FirstOrDefaultAsync(t => t.ProductId == productId && t.LanguageCode == language);
            return translation;
        }
    }
}
