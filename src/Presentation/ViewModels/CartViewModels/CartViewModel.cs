using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.CartViewModels
{
    public class CartViewModel
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
