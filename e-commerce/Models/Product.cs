using System.ComponentModel.DataAnnotations;
using e_commerce.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Product
{
    public int ProductID { get; set; }
    [Required]
    [Display(Name = "Product Name" )]
    public string? ProductName { get; set; }
    [Required]

    [Display(Name = "Product Picture Url")]
  
    public string? ProductImageUrl { get; set; }

    [Display(Name = "Product Price")]
    public double ProductPrice { get; set; }
    [ValidateNever]

    //Relationships

    public List<Product_Seller>? Products_Sellers { get; set; }

}