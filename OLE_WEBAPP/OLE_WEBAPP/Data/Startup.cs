//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
//using OLE_WEBAPP.Data;
//using OLE_WEBAPP.Models;

//public class Startup
//{
//    private IConfiguration Configuration { get; }

//    public Startup(IConfiguration configuration)
//    {
//        Configuration = configuration;
//    }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        var serverVersion = new MySqlServerVersion(new Version(5, 7, 39));

//        services.AddDbContext<AppDbContext>(options =>
//            options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), serverVersion));

//        services.AddIdentity<Account, IdentityRole>(options =>
//        {
//            // Configure password requirements, lockout, etc.
//            options.SignIn.RequireConfirmedAccount = true;
//        })
//.AddEntityFrameworkStores<AppDbContext>()
//.AddDefaultTokenProviders()
//.AddSignInManager<SignInManager<Account>>();


//        services.AddScoped<SignInManager<Account>>();

//        services.AddMvc();

//        services.ConfigureApplicationCookie(options =>
//        {
//            options.Cookie.HttpOnly = true;
//            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//            options.LoginPath = "/LogIn/Login"; // Change this to your login path
//            options.AccessDeniedPath = "/Home/AccessDenied"; // Change this to your access denied path
//            options.SlidingExpiration = true;
//        });
//    }
//}