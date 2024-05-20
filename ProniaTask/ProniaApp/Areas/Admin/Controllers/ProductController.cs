using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaApp.DataAccesLayer;
using ProniaApp.Extention;
using ProniaApp.Models;
using ProniaApp.ViewModels.Products;

namespace ProniaApp.Areas.Admin.Controllers
{
        [Area("Admin")]   
    public class ProductController(ProniaDbContext _context,IWebHostEnvironment _env) : Controller
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVm data)
        {
            if (!data.ImageUrl.IsValidType
                ("image"))
            {
                ModelState.AddModelError("ImageUrl", "Faylin formati duzgun deyil sekil elave edin");
            }

            if (!data.ImageUrl.IsValidLength(1000))
            {
                ModelState.AddModelError("ImageUrl", "Faylin olcusu 10 kb dan cox olmamalidir");
            }

            if (!ModelState.IsValid)
            {
                return View(data);
            }
            var file = data.ImageUrl;
            string ext = Path.GetExtension(file.FileName);
            string newName=Path.GetRandomFileName();
            string fileName = await data.ImageUrl.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "products"));
            await _context.Products.AddAsync(new Models.Product
            {
                CostPrice = data.CostPrice,
                Discount = data.Discount,
                CreatedTime = DateTime.Now,
                IsDeleted = false,
                Name = data.Name,
                Raiting = data.Raiting,
                SellPrice = data.SellPrice,
                StockCount = data.StockCount,
                Images = new List<ProductImage>(),
               ImageUrl  = Path.Combine("imgs", "products"),
            }) ;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

            foreach (var img in data.ImageFiels)
            {
                string imgName = await img.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "products"));
                product.Add(new ProductImage
                {
                    ImageUrl = Path.Combine("imgs", "products", imgName),
                    CreatedTime = DateTime.Now,
                    IsDeleted = false,
                });
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
