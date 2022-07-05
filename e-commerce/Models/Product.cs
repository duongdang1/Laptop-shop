using e_commerce.Models;
using ecommerce.Data.Base;

namespace e_commerce.Models
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImageUrl { get; set; }

        public double ProductPrice { get; set; }
    }
}
