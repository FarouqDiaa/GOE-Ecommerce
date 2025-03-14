
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.CartItemDTOs
{
    class BaseCartItemDTO
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid CartId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }
}
