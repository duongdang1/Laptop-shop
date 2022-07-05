using System.ComponentModel.DataAnnotations;

namespace e_commerce.Data.Models
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Name is Required")]
        public string? ProductName { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }

        [Display(Name = "Product Image")]
        [Required(ErrorMessage = "Product Image is Required")]
        public string? ProductImageUrl { get; set; }
    }
}
