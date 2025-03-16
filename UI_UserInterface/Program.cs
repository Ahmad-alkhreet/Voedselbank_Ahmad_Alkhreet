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
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied"; // ✅ Voorkom dubbele declaratie
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });


builder.Services.AddRazorPages(options =>
{
    options.Conventions.AllowAnonymousToPage("/Account/Login");
    options.Conventions.AllowAnonymousToPage("/Account/Logout");
    options.Conventions.AuthorizeFolder("/Food"); // ✅ Vereist login voor /Food-pagina’s
    options.Conventions.AuthorizePage("/Food/Index"); // ✅ Zorgt ervoor dat deze pagina echt beveiligd is

});

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


// Bouw de app
var app = builder.Build();

// Middleware-configuratie
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // ✅ Activeer sessie middleware
app.UseAuthentication();
app.UseAuthorization();

// Map Razor Pages en Controllers correct
app.MapRazorPages();
app.MapControllers(); // ✅ Belangrijk als je API's gebruikt

// . Stel een standaardpagina in als fallback
app.MapFallbackToPage("/Index"); // ✅ Gebruikers zonder geldige route worden naar home geleid

//  Start de applicatie
app.Run();