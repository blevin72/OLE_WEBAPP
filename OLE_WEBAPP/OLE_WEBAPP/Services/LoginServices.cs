using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OLE_WEBAPP.Interfaces;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Services
{
	public class LoginServices : ILoginServices
	{
        private readonly SignInManager<Account> _signInManager;

        //constructor injects an instance of SignInManager<Account> ^ for login services
		public LoginServices(SignInManager<Account> signInManager)
		{
            _signInManager = signInManager;
		}

        public async Task<SignInResult> SignInAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
        }
    }
}