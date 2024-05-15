namespace ProniaApp.ViewModels.Products
{
    public class CreateProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Discount { get; set; }
        public int StockCount { get; set; }
        public int Raiting { get; set; }
        public IFormFile ImageUrl { get; set; }
        public IEnumerable<IFormFile> ImageFiels { get; set; }

    }
}
