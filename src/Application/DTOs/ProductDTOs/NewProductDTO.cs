
namespace Application.DTOs.ProductDTOs
{
    class NewProductDTO : BaseProductDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
