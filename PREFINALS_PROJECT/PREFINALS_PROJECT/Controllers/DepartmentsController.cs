using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREFINALS_PROJECT.Data;

namespace PREFINALS_PROJECT.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _context.Departments
                .Include(d => d.Employees)
                .AsNoTracking()
                .ToListAsync();

            return View(departments);
        }
    }
}
