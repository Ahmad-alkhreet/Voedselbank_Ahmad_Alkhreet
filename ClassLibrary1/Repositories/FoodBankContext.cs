using Microsoft.EntityFrameworkCore;
using Voedselbank.Domain.Models;
using Voedselbank.Domain.Inheritance;


namespace Voedselbank.DataAccess
{
    public class FoodBankContext : DbContext
    {
        public FoodBankContext(DbContextOptions<FoodBankContext> options) : base(options) { }

        public DbSet<User> Users { get; private set; }
        public DbSet<FoodProduct> FoodProducts { get; private set; }
        public DbSet<Distribution> Distributions { get; private set; }
    }
}
