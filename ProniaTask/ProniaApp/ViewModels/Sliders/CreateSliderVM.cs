using System.ComponentModel.DataAnnotations;

namespace ProniaApp.ViewModels.Sliders
{
    public class CreateSliderVM
    {
        [MaxLength(32, ErrorMessage = "En cox 32"), Required]
        public string Title { get; set; }

        [MaxLength(64, ErrorMessage = "EN cox 32"), Required]
        public string SubTitle { get; set; }

        [Range(0, 100, ErrorMessage = "100 ile 0 arasinda")]
        public int Discount { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}