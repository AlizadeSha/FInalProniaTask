using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaApp.DataAccesLayer;
using ProniaApp.Models;
using ProniaApp.ViewModels.Category;

namespace ProniaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProniaDbContext _context;

        public HomeController(ProniaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.Where(x=>x.IsDeleted==false).Select(x=> new GetCategoryVM {Id=x.Id,Name=x.Namee }).ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Test(string name) {
            if (string.IsNullOrWhiteSpace(name)) return BadRequest();
            Category cat = new Category()
            { Namee = name,CreatedTime=DateTime.Now,IsDeleted=false };
           await _context.Categories.AddAsync(cat);
            await _context.SaveChangesAsync();
            return Content(name);
        }

        public async Task<IActionResult>Contact()
        {
            return View();
        }


        public async Task<IActionResult>Shop()
        {
            return View();
        }
        public async Task<IActionResult>About()
        {
            return View();
        }
    

    }
}
