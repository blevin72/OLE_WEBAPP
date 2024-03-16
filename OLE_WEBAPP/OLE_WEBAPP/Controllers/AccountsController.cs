using Microsoft.AspNetCore.Mvc;
using OLE_WEBAPP.Interfaces;
using OLE_WEBAPP.Models;
using System.Threading.Tasks;

public class AccountsController : Controller
{
    private readonly IAccountServices _accountService;

    // Constructor injection for IAccountService
    public AccountsController(IAccountServices accountService)
    {
        _accountService = accountService;
    }

    // Action method for displaying the registration form
    // GET 
    public IActionResult Register()
    {
        return View();
    }

    // Action method for handling the registration form submission
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Call the RegisterAsync method from the account service
            var result = await _accountService.RegisterAsync(model);
            if (result.Succeeded)
            {
                // Set a success message in TempData
                TempData["RegistrationSuccess"] = "Registration successful!";
                // Redirect to the Login action of the LogIn controller
                return RedirectToAction("Login", "LogIn");
            }
            else
            {
                // If registration fails, add model errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View(model);
    }

    // Action method for displaying a list of accounts
    public async Task<IActionResult> Index()
    {
        // Retrieve accounts asynchronously
        var accounts = await _accountService.GetAccountsAsync();
        return View(accounts);
    }
}