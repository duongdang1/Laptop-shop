using e_commerce.Data.Models;
using e_commerce.Data.Services;
using e_commerce.Data.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Controllers
{
	[Authorize(Roles = UserRoles.Admin)]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
		[AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            var allProducts = await _service.GetAllAsync();
            return View(allProducts);
        }
		[AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
		{
            var allProducts = await _service.GetAllAsync();
			if (!string.IsNullOrEmpty(searchString))
			{
                var filteredResultNew = allProducts.Where(n => string.Equals(n.ProductName, searchString, StringComparison.CurrentCultureIgnoreCase));
                return View("Index",filteredResultNew);
			}
            return View("Index", allProducts);
		}
		
        [HttpPost]
        public IActionResult Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _service.AddProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
		[AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(int id)
        {
            var product = _service.GetProductByIdAsync(id);
            if (product == null) return View("Not Found");
            return View(product);
        }

        public IActionResult Update(int id, NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _service.UpdateProductAsync(product);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var product = _service.GetProductByIdAsync(id);
            if (product == null) return View("Not found");
            _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
