using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Data
{
    public static class IdentityConfig
    {
        // Configures identity-related services, abstracted data, called in program.cs
        public static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<Account, IdentityRole>(options =>
            {
                // Configure password requirements, lockout, etc.
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager<SignInManager<Account>>();
        }
    }
}