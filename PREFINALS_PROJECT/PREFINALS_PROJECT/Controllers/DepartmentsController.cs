using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREFINALS_PROJECT.Data; // Ensure this matches Member 2's DbContext namespace

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
                .Select(d => new
                {
                    d.Name,
                    d.Description,
                    d.IsActive,
                    EmployeeCount = d.Employees.Count
                })
                .ToListAsync();

            return View(departments);
        }
    }
}