using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Controllers
{
    public class UserController : Controller
    {
        private readonly ShopDbContext _context;

        public UserController(ShopDbContext context)
        {
            _context = context; 
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Users.ToListAsync();
            return View();
        }
    }
}
