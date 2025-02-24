using Microsoft.EntityFrameworkCore;
using Voedselbank.Database;
using Voedselbank.Domain.Interfaces;
using Voedselbank.DataAccess.Repositories;
using Voedselbank.BusinessLogic.Services;
using BusinessLogic.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Registreer de DbContext (SQLite in dit voorbeeld)
builder.Services.AddDbContext<FoodBankContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registreer de generieke Repository voor alle entiteiten
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Registreer specifieke services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FoodProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();