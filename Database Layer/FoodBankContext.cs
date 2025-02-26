using Microsoft.EntityFrameworkCore;
using Voedselbank.Domain.Models;
using Voedselbank.Domain.Inheritance;



namespace Voedselbank.Database
{
    public class FoodBankContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FoodProduct> FoodProducts { get; set; }
        public DbSet<Distribution> Distributions { get; set; }

        public FoodBankContext(DbContextOptions<FoodBankContext> options) : base(options) { }

    }
}
