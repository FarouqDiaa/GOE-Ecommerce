
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cart : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
