using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace mvcLab1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationIdentity> UserManager;
        private readonly SignInManager<ApplicationIdentity> SignInManager;

        public AccountController(UserManager<ApplicationIdentity> userManager,
            SignInManager<ApplicationIdentity> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                ApplicationIdentity user = new ApplicationIdentity
                {
                    UserName = userFromReq.UserName,
                    PasswordHash = userFromReq.Password,
                    address = userFromReq.address
                };

                IdentityResult result = await UserManager.CreateAsync(user, userFromReq.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false);
                    await UserManager.AddToRoleAsync(user, "Admin");

                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("Register", userFromReq);
        }
        #endregion

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginFromReq)
        {
            if (ModelState.IsValid)
            {
                ApplicationIdentity userFromDb = await UserManager.FindByNameAsync(loginFromReq.UserName);
                if (userFromDb != null)
                {
                    bool found = await UserManager.CheckPasswordAsync(userFromDb, loginFromReq.Password);
                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address", userFromDb.address));

                        await SignInManager.SignInWithClaimsAsync(userFromDb, loginFromReq.RememberMe, claims);

                        return RedirectToAction("Index", "Instructor");
                    }
                }
                ModelState.AddModelError("", "Invalid Acount");

            }
            return View("Login", loginFromReq);

        }


        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
