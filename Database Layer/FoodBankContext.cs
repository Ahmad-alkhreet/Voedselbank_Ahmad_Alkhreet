using Microsoft.EntityFrameworkCore;
using Voedselbank.Domain.Models;
using Voedselbank.Database.Models;
using Microsoft.EntityFrameworkCore.Sqlite;
using Voedselbank.Domain.Inheritance;

namespace Voedselbank.Database;

public class FoodBankContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<FoodProduct> FoodProducts { get; set; }
    public DbSet<Distribution> Distributions { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlite("Data Source=voedselbank.db"); // SQLite-database
    //}
}