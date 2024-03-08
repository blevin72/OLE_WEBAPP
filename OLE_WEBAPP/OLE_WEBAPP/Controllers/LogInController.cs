using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Controllers
{
    public class LogInController : Controller
    {
        private readonly SignInManager<Account> _signInManager;

        public LogInController(SignInManager<Account> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult IndexView()
        {
            return View();
        }

        // Login action
        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    TempData["ShowLoginIndicator"] = true;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}










//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Threading.Tasks;
//using OLE_WEBAPP.Models;

//namespace OLE_WEBAPP.Controllers
//{
//    public class LogInController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }

//        //Login action
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Login(LoginViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
//                if (result.Succeeded)
//                {
//                    TempData["ShowLoginIndicator"] = true;
//                    return RedirectToAction("Index", "Home"); // Redirect to the home page after successful login
//                }
//                else
//                {
//                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
//                    return View(model); // Return the same model that was posted back
//                }
//            }
//            return View(model);
//        }

//        public IActionResult Register()
//        {
//            return View();
//        }
//    }
//}