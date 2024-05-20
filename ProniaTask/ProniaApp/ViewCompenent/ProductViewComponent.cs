using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaApp.Models;
using ProniaApp.DataAccesLayer;

namespace ProniaApp.ViewCompenent
{
    public class ProductViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int order = 1)
        {
            List<Product> products = null;
            switch (order)
            {
                case 1:
                    products = await _context.Products.OrderBy(p => p.Name).Take(8).ToListAsync();
                    break;

                case 2:
                    products = await _context.Products.OrderByDescending(p => p.SellPrice).Take(8).ToListAsync();
                    break;
                case 3:
                    products = await _context.Products.OrderBy(p => p.CreatedTime).Take(8).ToListAsync();
                    break;



            }
            return View(products);
        }
    }
}
