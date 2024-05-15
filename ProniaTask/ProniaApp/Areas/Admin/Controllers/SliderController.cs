using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaApp.DataAccesLayer;
using ProniaApp.Models;
using ProniaApp.ViewModels.Sliders;


namespace ProniaApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ProniaDbContext _context;

        public SliderController(ProniaDbContext context)
        {

            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            var data = await _context.Sliders.Where(c => !c.IsDeleted).Select(s => new GetSliderVM
            {
                Id = s.Id,
                Discount = s.Discount,
                ImgUrl = s.ImgUrl,
                SubTitle = s.SubTitle,
                Title = s.Title



            }).ToListAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            Slider slider = new Slider
            {
                CreatedTime = DateTime.Now,
                ImgUrl = vm.ImgUrl,
                IsDeleted = false,
                SubTitle = vm.SubTitle,
                Title = vm.Title,
                Discount = vm.Discount
            };

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null && id < 1) { return BadRequest(); }

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null)
            {
                return NotFound();
            }

            UpdateSliderVM updatevm = new UpdateSliderVM
            {
                SubTitle = slider.SubTitle,
                Title = slider.Title,
                ImgUrl = slider.ImgUrl,
                Discount=slider.Discount,
                
            };


            return View(updatevm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSliderVM sliderVM, int? id)
        {
            if (id == null && id < 1) { return BadRequest(); }
            Slider existed = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (existed == null)
            {
                return NotFound();
            }

            existed.SubTitle = sliderVM.SubTitle;
            existed.Title = sliderVM.Title;
            existed.ImgUrl = sliderVM.ImgUrl;
            existed.Discount = sliderVM.Discount;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();


            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }



    }

}