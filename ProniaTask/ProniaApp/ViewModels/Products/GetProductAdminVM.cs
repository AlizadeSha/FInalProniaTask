using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaApp.ViewModels.Products
{
    public class GetProductAdminVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Discount { get; set; }
        public int StockCount { get; set; }
        public int Raiting { get; set; }
        public string ImageUrl { get; set; }

    }
}
