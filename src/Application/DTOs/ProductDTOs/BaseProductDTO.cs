using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ProductDTOs
{
    public abstract class BaseProductDTO
    {
        private const decimal MaxDecimalValue = 79228162514264337593543950335M;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name must be at least 4 characters and no more than 100 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, (double)MaxDecimalValue, ErrorMessage = "Price must be a positive value")]
        public required decimal Price { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive value")]
        public int Quantity { get; set; }
    }
}
