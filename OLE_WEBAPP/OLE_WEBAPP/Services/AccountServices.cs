using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using OLE_WEBAPP.Models;
using OLE_WEBAPP.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OLE_WEBAPP.Services
{
    public class AccountServices : IAccountService
    {
        private readonly UserManager<Account> _userManager;

        public AccountServices(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            // Retrieves all users from the database
            var accounts = await _userManager.Users.ToListAsync();

            // Converts the list of IdentityUser to a list of Account
            var result = accounts.Select(u => new Account
            {
                Id = u.Id,
                Username = u.UserName,
                Email = u.Email
                // Adds any other properties you want to retrieve
            }).ToList();

            return result;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            var user = new Account { Username = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

            }
            return result;
        }
    }
}