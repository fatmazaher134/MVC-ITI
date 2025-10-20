using Microsoft.AspNetCore.Mvc;

namespace mvcLab1.Controllers
{
    public class TestSessionController : Controller
    {
        public IActionResult SetSession(string name, int age)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session Variables set successfully.");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            return Content($"Name: {name},\t Age: {age}");
        }

        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return Content("Session cleared successfully.");
        }

        public IActionResult SetCookie(string name, int age)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(3);
            Response.Cookies.Append("Name", name, options);
            Response.Cookies.Append("Age", age.ToString(), options);
            return Content("Cookies set successfully.");
        }

        public IActionResult GetCookie()
        {
            string name = Request.Cookies["Name"];
            string age = Request.Cookies["Age"];
            return Content($"Name: {name},\t Age: {age}");
        }

        public IActionResult ClearCookie()
        {
            Response.Cookies.Delete("Name");
            Response.Cookies.Delete("Age");
            return Content("Cookies cleared successfully.");
        }
    }
}
