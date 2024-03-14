using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Interfaces
{
	public interface ILoginServices
	{
		Task<SignInResult> SignInAsync(LoginViewModel model);
	}
}

