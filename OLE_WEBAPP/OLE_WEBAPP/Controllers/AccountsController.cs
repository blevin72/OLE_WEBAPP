using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OLE_WEBAPP.Interfaces;
using OLE_WEBAPP.Models;

public class AccountsController : Controller
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public IActionResult RegisterView()
    {
        return View();
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










//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using OLE_WEBAPP.Data;
//using OLE_WEBAPP.Models;
//using OLE_WEBAPP.Controllers;

//namespace OLE_WEBAPP.Controllers
//{
//    public class AccountsController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly SignInManager<Account> _signInManager;
//        private readonly UserManager<Account> _userManager;

//        public AccountsController(AppDbContext context, SignInManager<Account> signInManager, UserManager<Account> userManager)
//        {
//            _context = context;
//            _signInManager = signInManager;
//            _userManager = userManager;
//        }

//        // GET: Accounts
//        public async Task<IActionResult> Index()
//        {
//            return _context.Accounts != null ?
//                View(await _context.Accounts.ToListAsync()) :
//                Problem("Entity set 'AppDbContext.Accounts' is null.");
//        }

//        // GET: Accounts/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Accounts == null)
//            {
//                return NotFound();
//            }

//            var account = await _context.Accounts
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (account == null)
//            {
//                return NotFound();
//            }

//            return View(account);
//        }

//        // GET: Accounts/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Accounts/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Username,Email,Hash,Salt,AccountCreationDate,LastLoginDate,EmailSubscription")] Account account)
//        {
//            // Your existing code for creating an account

//            return View(account);
//        }

//        // GET: Accounts/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var account = await _context.Accounts.FindAsync(id);
//            if (account == null)
//            {
//                return NotFound();
//            }

//            return View(account);
//        }

//        // POST: Accounts/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Email,Hash,Salt,AccountCreationDate,LastLoginDate,EmailSubscription")] Account account)
//        {
//            // Your existing code for editing an account

//            return View(account);
//        }

//        // GET: Accounts/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var account = await _context.Accounts
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (account == null)
//            {
//                return NotFound();
//            }

//            return View(account);
//        }

//        // POST: Accounts/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            // Your existing code for deleting an account

//            return RedirectToAction(nameof(Index));
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

//        private bool AccountExists(int id)
//        {
//            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
//        }

//        // POST: Accounts/Register
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Register(RegisterViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = new Account
//                {
//                    Username = model.Username,
//                    Email = model.Email,
//                    AccountCreationDate = DateTime.Now,
//                    LastLoginDate = DateTime.Now,
//                    EmailSubscription = 0
//                };

//                var result = await _userManager.CreateAsync(user, model.Password);

//                if (result.Succeeded)
//                {
//                    TempData["RegistrationSuccess"] = "Registration successful!";
//                    return RedirectToAction("Login", "Accounts");
//                }
//                else
//                {
//                    foreach (var error in result.Errors)
//                    {
//                        ModelState.AddModelError(string.Empty, error.Description);
//                    }
//                }
//            }
//            return View(model);
//        }
//    }
//}