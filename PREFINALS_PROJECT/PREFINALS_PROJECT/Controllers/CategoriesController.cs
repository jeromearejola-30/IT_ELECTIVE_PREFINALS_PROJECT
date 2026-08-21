using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREFINALS_PROJECT.Data;


namespace PREFINALS_PROJECT.Controllers;


public class CategoriesController : Controller
{
    private readonly AppDbContext _context;


    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        // Query top-level categories and eagerly load their subcategories
        var parentCategories = await _context.Categories
            .Include(c => c.SubCategories)
            .Where(c => c.ParentCategoryId == null)
            .ToListAsync();


        return View(parentCategories);
    }
}
