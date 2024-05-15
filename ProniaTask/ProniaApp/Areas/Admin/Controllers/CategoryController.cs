using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaApp.DataAccesLayer;
using ProniaApp.ViewModels.Category;
using ProniaApp.DataAccesLayer;
using ProniaApp.ViewModels.Category;
using ProniaApp.ViewModels.Sliders;
using ProniaApp.Models;


namespace ProniaApp.Areas.Admin.Controllers
{
        [Area("Admin")]
           
    public class CategoryController(ProniaDbContext _context) : Controller
    {



        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.Where(x => !x.IsDeleted).Select(s => new GetCategoryVM
            {
                Id = s.Id,
                Name = s.Namee,
            }).ToListAsync();
            return View(data);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Category category = new Category
            {
                CreatedTime = DateTime.Now,
                Namee = vm.Name,
                IsDeleted = false
            };


            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null && id < 1) { return BadRequest(); }

            Category category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            UpdateCategoryVm updatevm = new UpdateCategoryVm
            {
                Name = category.Namee,
            };


            return View(updatevm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateCategoryVm vm)
        {
            if (id == null && id < 1) { return BadRequest(); }
            Category existed = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);

            if (existed == null)
            {
                return NotFound();
            }

            existed.Namee = vm.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();
                

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

    }
}