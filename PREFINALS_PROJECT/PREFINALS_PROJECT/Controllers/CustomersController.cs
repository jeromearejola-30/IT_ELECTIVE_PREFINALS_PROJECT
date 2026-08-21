using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREFINALS_PROJECT.Data;

namespace PREFINALS_PROJECT.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var customers = from c in _context.Customers select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.CompanyName.Contains(searchString)||
                                                 c.ContactName.Contains(searchString)||
                                                 c.Email.Contains(searchString));
            }

            return View(await customers.AsNoTracking().ToListAsync());
        }
    }
}