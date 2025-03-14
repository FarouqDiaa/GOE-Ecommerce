
namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<ProductTranslation> Translations { get; set; } = [];
    }
}
