using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREFINALS_PROJECT.Data;

namespace PREFINALS_PROJECT.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string priorityFilter)
        {
            ViewData["CurrentSearch"] = searchString;
            ViewData["CurrentPriority"] = priorityFilter;

            var tickets = from t in _context.Tickets select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(t => t.Title.Contains(searchString) ||
                                             t.Description.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(priorityFilter))
            {
                tickets = tickets.Where(t => t.Priority == priorityFilter);
            }

            return View(await tickets.AsNoTracking().ToListAsync());
        }
    }
}
