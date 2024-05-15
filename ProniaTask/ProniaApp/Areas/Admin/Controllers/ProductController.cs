using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaApp.DataAccesLayer;
using ProniaApp.ViewModels.Products;

namespace ProniaApp.Areas.Admin.Controllers
{
        [Area("Admin")]   
    public class ProductController(ProniaDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.Select(p=>new GetProductAdminVM 
            {
            CostPrice = p.CostPrice,
            Discount = p.Discount,
            ImageUrl = p.ImageUrl,
            Name = p.Name,
            Raiting = p.Raiting,
            SellPrice = p.SellPrice,
            StockCount = p.StockCount,
            Id = p.Id
            
            }).ToListAsync());
        }

        public async Task<IActionResult> Create() 
        {
        return View();
        }
    }
}
