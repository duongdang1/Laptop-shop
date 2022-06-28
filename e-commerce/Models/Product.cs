using e_commerce.Models;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductImageUrl { get; set; }

    public double ProductPrice { get; set; }

    //Relationships

    public List<Product_Seller> Products_Sellers { get; set; }

}