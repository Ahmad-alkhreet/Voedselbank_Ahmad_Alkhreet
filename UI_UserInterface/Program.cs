using Microsoft.EntityFrameworkCore;
using Voedselbank.Database;
using Voedselbank.Domain.Interfaces;
using Voedselbank.DataAccess.Repositories;
using Voedselbank.BusinessLogic.Services;

var builder = WebApplication.CreateBuilder(args);


// Voeg de databasecontext toe met de MySQL-connectionstring
builder.Services.AddDbContext<FoodBankContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));
    


// Voeg repositories toe aan de DI-container
builder.Services.AddScoped<IFoodProductRepository, FoodProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Voeg services toe
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FoodProductService>();
builder.Services.AddScoped<DistributionService>();

var app = builder.Build();

// Configureer de HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
