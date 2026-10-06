using Microsoft.AspNetCore.Mvc;

namespace COMP2139_ICE.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/About
        public IActionResult About()
        {
            return View();
        }
    }
}
