using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

public class ShopDbContext : DbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    internal Task GetAllAsync()
    {
        throw new NotImplementedException();
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