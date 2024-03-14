using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OLE_WEBAPP.Models;
using OLE_WEBAPP.Interfaces;

namespace OLE_WEBAPP.Controllers
{
    public class LogInController : Controller
    {
        private readonly ILoginServices _loginServices;

        // Constructor injects instance of ILoginServices
        public LogInController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        // GET Action method for displaying the Manage Account view
        public IActionResult Index()
        {
            return View();
        }

        // GET Action method for displaying the Login view
        public IActionResult Login()
        {
            return View();
        }

        // POST action method for handling the login form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to sign in the user using the provided email and password
                var result = await _loginServices.SignInAsync(model);
                if (result.Succeeded)
                {
                    // If login is successful, redirect to the home page
                    TempData["ShowLoginIndicator"] = true; // Optional: Setting a temporary data to indicate successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If login fails, display an error message
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}