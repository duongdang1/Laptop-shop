using e_commerce.Data.Models;
using e_commerce.Models;
using ecommerce.Data.Base;
using System.Collections.Generic;

namespace e_commerce.Data.Services
{
	public interface IProductService : IEntityBaseRepository<Product>
    {	
		Task<Product> GetProductByIdAsync(int id);
		Task AddProductAsync(NewProductVM data);
		Task UpdateProductAsync(NewProductVM data); 
	}
}
