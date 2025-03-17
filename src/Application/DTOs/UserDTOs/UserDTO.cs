
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.UserDTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
