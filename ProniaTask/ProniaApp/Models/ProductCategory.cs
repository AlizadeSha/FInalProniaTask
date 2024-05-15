namespace ProniaApp.Models
{
    public class ProductCategory :BaseModels
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public Product? Product { get; set; }

        
    }
}
