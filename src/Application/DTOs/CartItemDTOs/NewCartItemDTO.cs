
namespace Application.DTOs.CartItemDTOs
{
    public class NewCartItemDTO : BaseCartItemDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
