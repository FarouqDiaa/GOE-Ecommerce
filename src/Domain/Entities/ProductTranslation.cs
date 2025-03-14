
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ProductTranslation : BaseEntity
    {
        [Required]
        public Guid ProductId { get; set; }

        public Product Product { get; set; } = null!;

        [Required]
        [StringLength(5, ErrorMessage = "Language code cannot be longer than 5 characters.")]
        public string LanguageCode { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = null!;

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string? Description { get; set; }
    }
}
