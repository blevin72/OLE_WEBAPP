using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Services
{
	public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<Account>
	{
		public CustomClaimsPrincipalFactory(UserManager<Account> userManager,
                IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
		{
		}

		protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Account user)
		{
			var identity = await base.GenerateClaimsAsync(user);
			return identity;
		}
	}
}