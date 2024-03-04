using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OLE_WEBAPP.Data;
using OLE_WEBAPP.Models;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Other ConfigureServices code...

        var serverVersion = new MySqlServerVersion(new Version(5, 7, 9));

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), serverVersion));

        services.AddIdentity<Account, IdentityRole>(options =>
        {
            // Configure password requirements, lockout, etc.
            options.SignIn.RequireConfirmedAccount = true;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped<SignInManager<Account>>();

        services.AddControllersWithViews();
    }
}