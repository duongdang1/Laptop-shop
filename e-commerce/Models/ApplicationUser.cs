using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace e_commerce.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Full name")]
        public string? Fullname { get; set; }
    }
}
