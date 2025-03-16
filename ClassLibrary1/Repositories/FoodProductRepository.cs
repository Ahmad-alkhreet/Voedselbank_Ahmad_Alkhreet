using Voedselbank.Domain.Interfaces;
using Voedselbank.Domain.Models;
using Voedselbank.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Voedselbank.DataAccess.Repositories
{
    public class FoodProductRepository : IFoodProductRepository
    {
        private readonly FoodBankContext _context;
        private readonly ILogger<FoodProductRepository> _logger;

        public FoodProductRepository(FoodBankContext context, ILogger<FoodProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        //  Voeg een voedselproduct toe
        public async Task AddFoodProductAsync(FoodProduct product)
        {
            try
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product), "Voedselproduct mag niet null zijn.");

                await _context.FoodProducts.AddAsync(product);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Voedselproduct {product.GetFoodName()} toegevoegd.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Fout bij toevoegen voedselproduct.");
                throw;
            }
        }

        // Werk een enkel voedselproduct bij (Losse update)
        public async Task UpdateFoodProductAsync(FoodProduct product)
        {
            try
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product), "Voedselproduct mag niet null zijn.");

                _context.FoodProducts.Update(product); // ✅ Updaten in EF Core
                await _context.SaveChangesAsync();
                _logger.LogInformation($"✅ Voedselproduct {product.GetFoodName()} succesvol bijgewerkt.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Fout bij updaten voedselproduct.");
                throw;
            }
        }

        //  Bulk-update van meerdere voedselproducten
        public async Task UpdateFoodProductsAsync(List<FoodProduct> updatedProducts)
        {
            try
            {
                if (updatedProducts == null || updatedProducts.Count == 0)
                {
                    _logger.LogWarning("⚠️ Geen producten om bij te werken.");
                    return;
                }

                _context.FoodProducts.UpdateRange(updatedProducts); // ✅ Bulk-update
                await _context.SaveChangesAsync();
                _logger.LogInformation($"✅ {updatedProducts.Count} voedselproducten succesvol bijgewerkt.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Fout bij bulk-update van voedselproducten.");
                throw;
            }
        }

        //  Verwijder een voedselproduct
        public async Task DeleteFoodProductAsync(FoodProduct product)
        {
            try
            {
                _context.FoodProducts.Remove(product);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"✅ Voedselproduct {product.GetFoodName()} verwijderd.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Fout bij verwijderen voedselproduct.");
                throw;
            }
        }

        //  Haal een product op via ID
        public async Task<FoodProduct> GetFoodProductByIdAsync(int id)
        {
            try
            {
                return await _context.FoodProducts.SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"❌ Fout bij ophalen voedselproduct met ID {id}.");
                throw;
            }
        }

        // Haal alle voedselproducten op
        public async Task<IEnumerable<FoodProduct>> GetAllFoodProductsAsync()
        {
            try
            {
                return await _context.FoodProducts.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Fout bij ophalen van alle voedselproducten.");
                return new List<FoodProduct>();
            }
        }
    }
}
