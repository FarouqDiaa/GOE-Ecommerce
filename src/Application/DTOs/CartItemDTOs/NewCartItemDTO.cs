
namespace Application.DTOs.CartItemDTOs
{
    class NewCartItemDTO : BaseCartItemDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
