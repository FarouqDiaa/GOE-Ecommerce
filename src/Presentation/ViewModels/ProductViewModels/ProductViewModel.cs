using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public Guid id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }


        public int Quantity { get; set; }
    }
}
