using Microsoft.EntityFrameworkCore;
using Voedselbank.DataAccess.Repositories;
using Voedselbank.Domain.Models;
using Voedselbank.Domain.Interfaces;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Voedselbank.BusinessLogic.Services
{
    public class DistributionService
    {
        private readonly IUserRepository _userRepo;
        private readonly IFoodProductRepository _foodRepo;
        private readonly ILogger<DistributionService> _logger;
        private readonly IDistributionStrategy _distributionStrategy;

        public DistributionService(IUserRepository userRepo, IFoodProductRepository foodRepo, ILogger<DistributionService> logger, IDistributionStrategy distributionStrategy)
        {
            _userRepo = userRepo;
            _foodRepo = foodRepo;
            _logger = logger;
            _distributionStrategy = distributionStrategy;
        }

        public async Task AssignPackagesAsync()
        {
            try
            {
                var users = await _userRepo.GetAllUsersAsync();
                var availableProducts = (await _foodRepo.GetAllFoodProductsAsync())
                                            .Where(p => p.GetFoodAvailability() > 0 && !p.IsExpired())
                                            .OrderBy(p => p.GetFoodExpiryDate())
                                            .ToList();

                if (!users.Any())
                {
                    _logger.LogWarning("Geen gebruikers gevonden voor voedselpakketten.");
                    return;
                }

                if (!availableProducts.Any())
                {
                    _logger.LogWarning("Geen beschikbare producten gevonden voor verdeling.");
                    return;
                }

                await _distributionStrategy.DistributeAsync(users, availableProducts, _foodRepo, _logger);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fout bij het toewijzen van voedselpakketten.");
            }
        }
    }
}





//var updatedProducts = new List<FoodProduct>(); // Buffer voor bulk update

//foreach (var user in users)
//{
//    foreach (var product in availableProducts)
//    {
//        if (product.GetFoodAvailability() <= 0) continue; // Extra check, voorkomt onnodige iteraties

//        if (!user.HasDietaryRestriction(product))
//        {
//            product.ReduceAvailability();
//            updatedProducts.Add(product);
//        }
//    }
//}

//// Bulk update van producten, voorkomt dat we te vaak async calls maken
//if (updatedProducts.Any())
//{
//    await _foodRepo.UpdateFoodProductsAsync(updatedProducts);
//}