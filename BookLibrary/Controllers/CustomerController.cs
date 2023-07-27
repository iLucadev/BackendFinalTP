using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
