using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl{ get; set; }

        public double ProductPrice { get; set; }

        //Relationships

        public  List<Product_Seller> Products_Sellers { get; set; }

        //Information of the seller

        public int? SellerID { get; set; }
        [ForeignKey("SellerID")]

        public Seller Seller { get; set; }
    }
}
