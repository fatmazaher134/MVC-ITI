using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace mvcLab1.Controllers
{
    public class BindController : Controller
    {
        public IActionResult Welcome()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                string? name = User.Identity.Name;
                Claim? addressClaim = User.Claims
                    .FirstOrDefault(c => c.Type == "Address");
                string? address = addressClaim.Value;

                Claim? idClaim = User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                string? id = idClaim.Value;
                return Content($"Welcome {name} \t {id} \t {address}");
            }
            else
            {
                return Content("Welcome Guest");
            }
        }
    }
}
