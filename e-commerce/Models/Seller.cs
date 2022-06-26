using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        public string SellerFirstName { get; set; }

        public string SellerLastName { get; set; }

        public string SellerEmail { get; set; } 


        public string SellerPassword { get; set; }

        public int SellerPhone { get; set; }

        public int SellerReview { get; set; }   

        //Relationships

        public List<Product_Seller> Products_Sellers { get; set; }

        //Product information
        public int?  ProductID { get; set; }
        [ForeignKey("ProductID")]

        public Product Product { get; set; }
    }
}
