namespace ProniaApp.Models
{
    public class ProductImage :BaseModels
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
