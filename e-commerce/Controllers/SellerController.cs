using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Controllers
{
    public class SellerController : Controller
    {
        private readonly ShopDbContext _context;

        public SellerController(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Sellers.ToListAsync();
            return View();
        }
    }
}
