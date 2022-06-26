using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Data
{
    public class ShopDbContext : DbContext
    {   
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Seller>().HasKey(ps => new
            {
                ps.ProductID,
                ps.SellerID
            });
            //create a schema 
            //HasOne: has one element
            //with many: one to many 
            modelBuilder.Entity<Product_Seller>().HasOne(p => p.Product).WithMany(ps => ps.Products_Sellers).HasForeignKey(pi => pi.ProductID);
            modelBuilder.Entity<Product_Seller>().HasOne(s => s.Seller).WithMany(ps => ps.Products_Sellers).HasForeignKey(si => si.SellerID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Product_Seller> Products_Sellers { get; set; }


        public DbSet<User> Users { get; set; }
    }
}
