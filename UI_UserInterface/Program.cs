using Voedselbank.DataAccess;
using Voedselbank.DataAccess.Repositories;
using Voedselbank.Domain.Interfaces;
using Voedselbank.BusinessLogic.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  Haal de connectiestring op uit `appsettings.json`
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//  Voeg EF Core `DbContext` toe
builder.Services.AddDbContext<FoodBankContext>();

//  Registreer repositories en injecteer `FoodBankContext`
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFoodProductRepository, FoodProductRepository>();

//  Registreer services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FoodProductService>();

//  Voeg een distributed memory cache toe (voor sessies)
builder.Services.AddDistributedMemoryCache();

//  Voeg sessie-ondersteuning toe met configuratieopties
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//  Voeg authenticatie met cookies toe
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  // ✅ Voorkomt redirect-loop
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Error";
    });

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Account/Login");
});

builder.Services.AddAuthorization();
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

// Bouw de app
var app = builder.Build();

// Middleware-configuratie
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Activeer sessie middleware
app.UseAuthentication();
app.UseAuthorization();

// Map Razor Pages en stel de standaard route in
app.MapRazorPages();
app.MapFallbackToPage("/Account/Login");

// Start de applicatie
app.Run();
