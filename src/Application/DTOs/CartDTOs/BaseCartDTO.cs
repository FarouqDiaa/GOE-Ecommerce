
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.CartDTOs
{
    public abstract class BaseCartDTO
    {
        [Required]
        public Guid UserId { get; set; }

    }
}
