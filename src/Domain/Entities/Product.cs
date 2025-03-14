
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        private const decimal MaxDecimalValue = decimal.MaxValue;

        [Required]
        [Range(0, (double)MaxDecimalValue, ErrorMessage = "Price must be a non-negative value.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public int Quantity { get; set; }

        public ICollection<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();
    }
}
