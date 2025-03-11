using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Models;
using Voedselbank.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Voedselbank.DataAccess.Repositories
{
    public class FoodProductRepository : IFoodProductRepository
    {
        private readonly FoodBankContext _context;

        public FoodProductRepository(FoodBankContext context)
        {
            _context = context;
        }

        public async Task AddFoodProductAsync(FoodProduct product)
        {
            await _context.FoodProducts.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFoodProductAsync(FoodProduct product)
        {
            _context.FoodProducts.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodProductAsync(FoodProduct product)
        {
            _context.FoodProducts.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<FoodProduct> GetFoodProductByIdAsync(int id)
        {
            return await _context.FoodProducts.FindAsync(id);
        }

        public async Task<IEnumerable<FoodProduct>> GetAllFoodProductsAsync()
        {
            return await _context.FoodProducts.ToListAsync();
        }
    }
}
