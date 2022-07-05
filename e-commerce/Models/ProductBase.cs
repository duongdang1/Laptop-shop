using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class ProductBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }
        [Required(ErrorMessage = "Product's name is required")]

        [Display(Name = "Product Picture Url")]

        public string? ProductImageUrl { get; set; }
        [Required(ErrorMessage = "Product's image is required")]
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }
    }
}