using e_commerce.Data.Models;
using e_commerce.Models;
using eTickets.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService

    {
        private readonly ShopDbContext _context;
        public ProductService(ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                ProductName = data.ProductName,
                ProductImageUrl = data.ProductImageUrl,
                ProductPrice = data.Price
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(dbProduct != null)
            {
                dbProduct.ProductName = data.ProductName;
                dbProduct.ProductImageUrl = data.ProductImageUrl;
                dbProduct.ProductPrice = data.Price;
                await _context.SaveChangesAsync();
            }
        }

       
    }
}
