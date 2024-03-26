using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OLE_WEBAPP.Models;
using OLE_WEBAPP.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OLE_WEBAPP.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<Account> _userManager;
        // constructor injects an instance of UserManager<Account> ^ for interacting with user related data
        public AccountServices(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        // Retrieves all accounts asynchronously
        public async Task<List<Account>> GetAccountsAsync()
        {
            // Retrieves all users from the database. _userManager is used to fetch users
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

        // Registers a new account asynchronously
        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            // Create a new Account instance from the provided model
            var user = new Account { Username = model.Username, Email = model.Email };

            // Attempt to create the user in the database
            var result = await _userManager.CreateAsync(user, model.Password);

            // Optionally handle success or failure here

            return result;
        }
    }
}