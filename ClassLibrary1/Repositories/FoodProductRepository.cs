using System.Collections.Generic;
using System.Linq;
using Voedselbank.Database;
using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Models;



namespace Voedselbank.DataAccess.Repositories
{
    public class FoodProductRepository : IFoodProductRepository
    {
        private readonly FoodBankContext _context;

        public FoodProductRepository(FoodBankContext context)
        {
            _context = context;
        }

        public void AddFoodProduct(FoodProduct product)
        {
            _context.FoodProducts.Add(product);
            _context.SaveChanges();
        }

        public void UpdateFoodProduct(FoodProduct product)
        {
            _context.FoodProducts.Update(product);
            _context.SaveChanges();
        }

        public void DeleteFoodProduct(FoodProduct product)
        {
            _context.FoodProducts.Remove(product);
            _context.SaveChanges();
        }

        public FoodProduct GetFoodProductById(int id)
        {
            return _context.FoodProducts.Find(id);
        }

        public List<FoodProduct> GetAllFoodProducts()
        {
            return _context.FoodProducts.ToList();
        }
    }
}
