using Voedselbank.DataAccess.Repositories;
using Voedselbank.Domain.Interfaces;
using Voedselbank.BusinessLogic.Services;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout to 30 minutes
    options.Cookie.HttpOnly = true; // Ensure the session cookie is HTTP only
    options.Cookie.IsEssential = true; // Mark session cookie as essential
});

// Register repositories with their interfaces
builder.Services.AddScoped<IFoodProductRepository, FoodProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add database connection
builder.Services.AddTransient<IDbConnection>((sp) =>
    new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));

// Register services
builder.Services.AddScoped<FoodProductService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DistributionService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Enable session middleware
app.UseAuthorization();

// Map Razor pages
app.MapRazorPages();
app.Run();
