using e_commerce.Models;

public class Seller
{
    public int SellerId { get; set; }

    public string SellerFirstName { get; set; }

    public string SellerLastName { get; set; }

    public string SellerEmail { get; set; }


    public string SellerPassword { get; set; }

    public int SellerPhone { get; set; }

    public int SellerReview { get; set; }

    //Relationships

    public List<Product_Seller> Products_Sellers { get; set; }
}