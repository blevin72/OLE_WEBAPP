using Microsoft.AspNetCore.Mvc;
using OLE_WEBAPP.Interfaces;
using OLE_WEBAPP.Models;
using System.Threading.Tasks;

public class AccountsController : Controller
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.RegisterAsync(model);
            if (result.Succeeded)
            {
                TempData["RegistrationSuccess"] = "Registration successful!";
                return RedirectToAction("Login", "LogIn");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View(model);
    }

    public async Task<IActionResult> Index()
    {
        var accounts = await _accountService.GetAccountsAsync();
        return View(accounts);
    }
}