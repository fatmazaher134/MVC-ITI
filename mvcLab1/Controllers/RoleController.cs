using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace mvcLab1.Controllers
{

    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleFromReq)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { 
                    Name = roleFromReq.RoleName
                };

                IdentityResult result = await RoleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View("Create", roleFromReq);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                } 
                
            }


            return View("Create", roleFromReq);
        }

    }
}
