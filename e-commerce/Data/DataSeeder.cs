using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

public class DataSeeder
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var shopDbContext = new ShopDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ShopDbContext>>()))
        {

            if (!shopDbContext.Users.Any())
            {
                var User_List = new List<User>()
                    {
                        new User()
                        {

                            FirstName = "David",
                            LastName = "D",
                            Email = "davidd.com",
                            Password = "1234"
                        },

                        new User()
                        {

                            FirstName = "Alex",
                            LastName = "S",
                            Email="alexs@gmail.com",
                            Password="1234"
                        }
                    };
                shopDbContext.Users.AddRange(User_List);
                shopDbContext.SaveChanges();
            }


            if (!shopDbContext.Products.Any() && !shopDbContext.Sellers.Any())
            {

                var product1 = new Product()
                {

                    ProductName = "Macbook Pro 2022",
                    ProductImageUrl = "https://i.ibb.co/7nWnHc7/macbookpro.jpg",
                    ProductPrice = 2000.00

                };
                var product2 = new Product()
                {

                    ProductName = "Dell XPS",
                    ProductImageUrl = "https://i.ibb.co/KXxJsfM/dellxps.jpg",
                    ProductPrice = 1999.00

                };
                var seller1 = new Seller()
                {

                    SellerFirstName = "Da",
                    SellerLastName = "Du",
                    SellerEmail = "abcd@gmail.com",
                    SellerPassword = "1234",
                    SellerPhone = 1900,
                    SellerReview = 5


                };

                var seller2 = new Seller()
                {

                    SellerFirstName = "Ng",
                    SellerLastName = "Le",
                    SellerEmail = "bcdez@gmail.com",
                    SellerPassword = "1234",
                    SellerPhone = 1800,
                    SellerReview = 5

                };


                var pslist = new List<Product_Seller>()
            {
                new Product_Seller() { Product = product1, Seller = seller1 },
                new Product_Seller() { Product = product1, Seller = seller2 },


                new Product_Seller() { Product = product2, Seller = seller1 },

            };
                shopDbContext.Products_Sellers.AddRange(pslist);

                shopDbContext.SaveChanges();

            }
        }
    }
}