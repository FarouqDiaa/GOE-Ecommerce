
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.CartDTOs
{
    public class NewCartDTO : BaseCartDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
