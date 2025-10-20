using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcLab1.Models;

namespace mvcLab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult checkNumber(int num)
        {
            if (num % 2 == 0)
            {
                return Content("The number is even.");
            }
            else
            {
                return View("OddNumberView");
            }
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
