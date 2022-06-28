using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {

    }
    public DbSet<Seller> Sellers { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Product_Seller> Products_Sellers { get; set; }


    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product_Seller>().HasKey(i => new { i.ProductID, i.SellerID });
    }
}