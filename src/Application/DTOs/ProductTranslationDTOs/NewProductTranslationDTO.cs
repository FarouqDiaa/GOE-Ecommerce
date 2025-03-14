
namespace Application.DTOs.ProductTranslationDTOs
{
    class NewProductTranslationDTO : BaseProductTranslationDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
