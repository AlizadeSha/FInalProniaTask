namespace ProniaApp.Models
{
    public class Category : BaseModels
    {
        public String Namee { get; set; }     
        public ICollection<ProductCategory>? productCategories { get; set;}
    }
}
