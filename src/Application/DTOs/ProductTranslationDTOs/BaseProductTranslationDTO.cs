using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ProductTranslationDTOs
{
    public abstract class BaseProductTranslationDTO
    {
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public required string LanguageCode { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
