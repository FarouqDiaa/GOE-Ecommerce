
namespace Application.DTOs.ProductTranslationDTOs
{
    public class NewProductTranslationDTO : BaseProductTranslationDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
