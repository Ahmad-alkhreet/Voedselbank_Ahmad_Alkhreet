using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Database.Models;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Database;

public class FoodBankContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<FoodProduct> FoodProducts { get; set; }
    public DbSet<Distribution> Distributions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=voedselbank.db"); // SQLite-database
    }
}