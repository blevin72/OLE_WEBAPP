using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OLE_WEBAPP.Data;
using OLE_WEBAPP.Interfaces;
using OLE_WEBAPP.Models;
using OLE_WEBAPP.Services;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(5, 7, 39));

// Add DbContext with MySQL provider
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));

// Configure Identity by calling method in Identity Config Class
IdentityConfig.ConfigureIdentity(builder.Services);

// Add scoped services
builder.Services.AddScoped<SignInManager<Account>>();
builder.Services.AddScoped<UserManager<Account>>();
builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<ILoginServices, LoginServices>();
builder.Services.AddScoped<IPlayerServices, PlayerServices>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<Account>, CustomClaimsPrincipalFactory>();


// Add MVC services
builder.Services.AddMvc();

// Configure application cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    // Configure cookie properties
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    // Set login path
    options.LoginPath = "/Login/Login";

    // Set access denied path
    options.AccessDeniedPath = "/Home/AccessDenied";

    // Enable sliding expiration
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Configure exception handling for non-development environments
    app.UseExceptionHandler("/Home/Error");

    // Configure HTTP Strict Transport Security (HSTS)
    app.UseHsts();
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Serve static files
app.UseStaticFiles();

// Configure routing
app.UseRouting();

// Configure authorization
app.UseAuthorization();

// Configure default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application
app.Run();














//using System;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
//using OLE_WEBAPP.Data;
//using OLE_WEBAPP.Models;
//using OLE_WEBAPP.Interfaces;
//using OLE_WEBAPP.Services;
//using System.Configuration;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//// Get connection string from configuration
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//var serverVersion = new MySqlServerVersion(new Version(5, 7, 39));

//// Add DbContext with MySQL provider
//builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));

//// Configure Identity
//builder.Services.AddIdentity<Account, IdentityRole>(options =>
//{
//    // Configure password requirements, lockout, etc.
//    options.SignIn.RequireConfirmedAccount = true;
//})
//.AddEntityFrameworkStores<AppDbContext>()
//.AddDefaultTokenProviders()
//.AddSignInManager<SignInManager<Account>>();

//// Add scoped services
//builder.Services.AddScoped<SignInManager<Account>>();
//builder.Services.AddScoped<IAccountService, AccountServices>();

//// Add MVC services
//builder.Services.AddMvc();

//// Configure application cookie settings
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    // Configure cookie properties
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

//    // Set login path
//    options.LoginPath = "/Views/LogIn/LogIn"; // Change this to your login path

//    // Set access denied path
//    options.AccessDeniedPath = "/Home/AccessDenied"; // Change this to your access denied path

//    // Enable sliding expiration
//    options.SlidingExpiration = true;
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    // Configure exception handling for non-development environments
//    app.UseExceptionHandler("/Home/Error");

//    // Configure HTTP Strict Transport Security (HSTS)
//    app.UseHsts();
//}

//// Enable HTTPS redirection
//app.UseHttpsRedirection();

//// Serve static files
//app.UseStaticFiles();

//// Configure routing
//app.UseRouting();

//// Configure authorization
//app.UseAuthorization();

//// Configure default controller route
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//// Run the application
//app.Run();