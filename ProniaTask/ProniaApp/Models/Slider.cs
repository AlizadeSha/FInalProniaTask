using System.ComponentModel.DataAnnotations;

namespace ProniaApp.Models
{
   
        public class Slider : BaseModels
        {
            [MaxLength(32), Required]
            public string Title { get; set; }

            [MaxLength(64), Required]
            public string SubTitle { get; set; }

            [Range(0, 100)]
            public int Discount { get; set; }

            [Required]
            public string ImgUrl { get; set; }
        }
}
