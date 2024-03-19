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

// CustomClaimsPrincipalFactory (child class) is a custom implementation of UserClaimsPrincipalFactory<Account> (Parent/Base Class).
// It is responsible for generating claims-based identity for a user.
// Constructor for CustomClaimsPrincipalFactory, which takes UserManager<Account> and IOptions<IdentityOptions> as dependencies.
// Dependency injection is used to inject UserManager<Account> and IOptions<IdentityOptions> instances into this class.
// Override method to generate claims for the user.
// Call the base class method to generate the base claims identity.

// Additional custom logic can be added here to generate more claims based on user data.
// For example:
// identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

// Return the generated claims identity.