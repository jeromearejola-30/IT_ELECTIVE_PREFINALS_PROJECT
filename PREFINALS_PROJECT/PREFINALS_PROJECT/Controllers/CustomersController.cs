using Microsoft.AspNetCore.Mvc;

namespace PREFINALS_PROJECT.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
